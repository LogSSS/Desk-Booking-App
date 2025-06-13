import {
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
  ChangeDetectorRef,
  OnChanges,
  OnDestroy,
  SimpleChanges,
} from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import {
  Booking,
  UpsertBooking,
  WorkspaceType,
} from '../../models/booking.model';
import { Workspace } from '../../models/workspace.model';
import { BookingService } from '../../services/booking.service';
import { Subscription, combineLatest, startWith } from 'rxjs';

@Component({
  selector: 'app-booking-modal',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, DatePipe],
  providers: [DatePipe],
  templateUrl: './booking-modal.component.html',
})
export class BookingModalComponent implements OnInit, OnChanges, OnDestroy {
  @Input() booking?: Booking;
  @Input() workspaceForNewBooking?: Workspace;
  @Output() close = new EventEmitter<boolean>();

  bookingForm!: FormGroup;
  isEditMode = false;
  modalTitle = '';

  showSuccessState = false;
  successDetails: {
    roomSize: number;
    startDate: string;
    endDate: string;
    email: string;
    workspaceType: WorkspaceType;
  } | null = null;

  WorkspaceType = WorkspaceType;

  private subscriptions = new Subscription();

  workspaceTypes = [
    { id: WorkspaceType.OpenSpace, name: 'Open Space' },
    { id: WorkspaceType.PrivateRoom, name: 'Private rooms' },
    { id: WorkspaceType.MeetingRoom, name: 'Meeting rooms' },
  ];
  privateRoomSizes = [1, 2, 5, 10];
  meetingRoomSizes = [10, 20];

  startDays: number[] = [];
  endDays: number[] = [];
  days: number[] = Array.from({ length: 31 }, (_, i) => i + 1);
  months: { value: number; name: string }[] = [
    { value: 0, name: 'January' },
    { value: 1, name: 'February' },
    { value: 2, name: 'March' },
    { value: 3, name: 'April' },
    { value: 4, name: 'May' },
    { value: 5, name: 'June' },
    { value: 6, name: 'July' },
    { value: 7, name: 'August' },
    { value: 8, name: 'September' },
    { value: 9, name: 'October' },
    { value: 10, name: 'November' },
    { value: 11, name: 'December' },
  ];
  years: number[] = Array.from(
    { length: 5 },
    (_, i) => new Date().getFullYear() + i
  );
  times: string[] = this.generateTimeSlots();

  constructor(
    private fb: FormBuilder,
    private bookingService: BookingService,
    private router: Router,
    private datePipe: DatePipe,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.initForm();
    this.setupModal();
    this.listenToChanges();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (
      (changes['booking'] || changes['workspaceForNewBooking']) &&
      this.bookingForm
    ) {
      this.setupModal();
    }
  }

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }

  private setupModal(): void {
    this.isEditMode = !!this.booking;
    if (this.isEditMode) {
      this.modalTitle = 'Edit your booking';
      this.populateFormForEdit();
    } else {
      this.modalTitle = 'Book a workspace';
      this.prepareFormForAdd();
    }
  }

  private initForm(): void {
    this.bookingForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      workspaceType: ['', Validators.required],
      roomSize: [null],
      startDay: [null, Validators.required],
      startMonth: [null, Validators.required],
      startYear: [null, Validators.required],
      startTime: ['', Validators.required],
      endDay: [null, Validators.required],
      endMonth: [null, Validators.required],
      endYear: [null, Validators.required],
      endTime: ['', Validators.required],
    });
  }

  private populateFormForEdit(): void {
    if (!this.booking || !this.booking.workspace) return;

    const startDate = new Date(this.booking.startDate);
    const endDate = new Date(this.booking.endDate);

    const formData = {
      name: this.booking.name,
      email: this.booking.email,
      workspaceType: this.booking.workspace.type,
      roomSize: this.booking.roomSize,
      startDay: startDate.getDate(),
      startMonth: startDate.getMonth(),
      startYear: startDate.getFullYear(),
      startTime: this.formatTimeForSelect(startDate),
      endDay: endDate.getDate(),
      endMonth: endDate.getMonth(),
      endYear: endDate.getFullYear(),
      endTime: this.formatTimeForSelect(endDate),
    };
    this.bookingForm.reset(formData);
    this.updateRoomSizeValidators(this.booking.workspace.type);
    this.updateDaysForDate(
      'start',
      startDate.getFullYear(),
      startDate.getMonth()
    );
    this.updateDaysForDate('end', endDate.getFullYear(), endDate.getMonth());
  }

  private prepareFormForAdd(): void {
    this.bookingForm.reset();

    if (this.workspaceForNewBooking) {
      this.bookingForm.patchValue({
        workspaceType: this.workspaceForNewBooking.type,
      });
    }

    const today = new Date();
    this.bookingForm.patchValue({
      startYear: today.getFullYear(),
      startMonth: today.getMonth(),
      startDay: today.getDate(),
      endYear: today.getFullYear(),
      endMonth: today.getMonth(),
      endDay: today.getDate(),
    });

    this.updateDaysForDate('start', today.getFullYear(), today.getMonth());
    this.updateDaysForDate('end', today.getFullYear(), today.getMonth());

    if (this.workspaceForNewBooking) {
      this.updateRoomSizeValidators(this.workspaceForNewBooking.type);
    }
  }

  private listenToChanges(): void {
    const workspaceType$ = this.bookingForm
      .get('workspaceType')!
      .valueChanges.pipe(
        startWith(this.bookingForm.get('workspaceType')!.value)
      );
    this.subscriptions.add(
      workspaceType$.subscribe((type) => {
        if (type == null) return;
        const workspaceType = Number(type);
        this.updateRoomSizeValidators(workspaceType);

        const roomSizeControl = this.bookingForm.get('roomSize');
        if (!roomSizeControl) return;

        switch (workspaceType) {
          case WorkspaceType.OpenSpace:
            roomSizeControl.setValue(null);
            break;
          case WorkspaceType.PrivateRoom:
            if (!this.privateRoomSizes.includes(roomSizeControl.value)) {
              roomSizeControl.setValue(null);
            }
            break;
          case WorkspaceType.MeetingRoom:
            if (!this.meetingRoomSizes.includes(roomSizeControl.value)) {
              roomSizeControl.setValue(null);
            }
            break;
        }
      })
    );

    const startMonth$ = this.bookingForm
      .get('startMonth')!
      .valueChanges.pipe(startWith(this.bookingForm.get('startMonth')!.value));
    const startYear$ = this.bookingForm
      .get('startYear')!
      .valueChanges.pipe(startWith(this.bookingForm.get('startYear')!.value));

    this.subscriptions.add(
      combineLatest([startMonth$, startYear$]).subscribe(([month, year]) => {
        if (month != null && year != null) {
          this.updateDaysForDate('start', year, Number(month));
        }
      })
    );
    const endMonth$ = this.bookingForm
      .get('endMonth')!
      .valueChanges.pipe(startWith(this.bookingForm.get('endMonth')!.value));
    const endYear$ = this.bookingForm
      .get('endYear')!
      .valueChanges.pipe(startWith(this.bookingForm.get('endYear')!.value));
    this.subscriptions.add(
      combineLatest([endMonth$, endYear$]).subscribe(([month, year]) => {
        if (month != null && year != null)
          this.updateDaysForDate('end', year, Number(month));
      })
    );
  }

  private updateDaysForDate(
    prefix: 'start' | 'end',
    year: number,
    month: number
  ): void {
    const daysInMonth = new Date(year, month + 1, 0).getDate();
    const daysArray = Array.from({ length: daysInMonth }, (_, i) => i + 1);

    if (prefix === 'start') {
      this.startDays = daysArray;
    } else {
      this.endDays = daysArray;
    }

    const dayControl = this.bookingForm.get(`${prefix}Day`);
    if (dayControl && dayControl.value > daysInMonth) {
      dayControl.setValue(null);
    }
  }

  private updateRoomSizeValidators(type: WorkspaceType): void {
    const roomSizeControl = this.bookingForm.get('roomSize');
    if (!roomSizeControl) return;

    if (type === WorkspaceType.OpenSpace) {
      roomSizeControl.clearValidators();
      roomSizeControl.setValue(null);
    } else {
      roomSizeControl.setValidators(Validators.required);
    }
    roomSizeControl.updateValueAndValidity();
  }

  saveChanges(): void {
    if (this.bookingForm.invalid) {
      this.bookingForm.markAllAsTouched();
      return;
    }

    const formVal = this.bookingForm.getRawValue();
    const workspaceType = Number(formVal.workspaceType);

    const startDate = new Date(
      formVal.startYear,
      formVal.startMonth,
      formVal.startDay,
      ...this.parseTime(formVal.startTime)
    );

    const endDate = new Date(
      formVal.endYear,
      formVal.endMonth,
      formVal.endDay,
      ...this.parseTime(formVal.endTime)
    );

    const payload: UpsertBooking = {
      name: formVal.name,
      email: formVal.email,

      workspaceId: workspaceType + 1,

      roomSize:
        workspaceType === WorkspaceType.OpenSpace
          ? 0
          : Number(formVal.roomSize),
      startDate: startDate.toISOString(),
      endDate: endDate.toISOString(),

      status: this.isEditMode ? this.booking!.status : 1,
      ownerId: this.isEditMode ? this.booking!.ownerId : -1,
    };

    if (this.isEditMode) {
      this.bookingService.updateBooking(this.booking!.id, payload).subscribe({
        next: () => this.close.emit(true),
        error: () => {
          alert('Update failed.');
          this.close.emit(false);
        },
      });
    } else {
      this.bookingService.createBooking(payload).subscribe({
        next: (createdBooking) => {
          this.successDetails = {
            roomSize: formVal.roomSize,
            startDate: startDate.toISOString(),
            endDate: endDate.toISOString(),
            email: formVal.email,
            workspaceType: workspaceType,
          };
          this.showSuccessState = true;
          this.cdr.detectChanges();
        },
        error: () => {
          alert('Booking creation failed.');
          this.close.emit(false);
        },
      });
    }
  }

  navigateToMyBookings(): void {
    this.showSuccessState = false;
    this.successDetails = null;
    this.close.emit(true);
    this.router.navigate(['/my']);
  }

  cancel(): void {
    this.showSuccessState = false;
    this.successDetails = null;
    this.close.emit(false);
  }

  closeModal(): void {
    this.showSuccessState = false;
    this.successDetails = null;
    this.close.emit(false);
  }

  private generateTimeSlots(): string[] {
    const slots = [];
    for (let h = 8; h <= 22; h++) {
      const hour12 = h > 12 ? h - 12 : h === 0 ? 12 : h;
      const period = h < 12 || h === 24 ? 'AM' : 'PM';
      if (h === 22) {
        slots.push('10:00 PM');
      } else {
        slots.push(`${hour12}:00 ${period}`);
      }
    }
    return slots;
  }

  private formatTimeForSelect(date: Date): string {
    const hours = date.getHours();
    const period = hours >= 12 ? 'PM' : 'AM';
    let hour12 = hours % 12;
    hour12 = hour12 ? hour12 : 12;
    return `${hour12}:00 ${period}`;
  }

  private parseTime(timeStr: string): [number, number] {
    const [time, period] = timeStr.split(' ');
    let [hours] = time.split(':').map(Number);
    if (period === 'PM' && hours < 12) hours += 12;
    if (period === 'AM' && hours === 12) hours = 0;
    return [hours, 0];
  }
}
