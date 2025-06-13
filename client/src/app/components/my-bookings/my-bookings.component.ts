import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

import {
  Observable,
  BehaviorSubject,
  switchMap,
  tap,
  catchError,
  of,
} from 'rxjs';
import { Booking, WorkspaceType } from '../../models/booking.model';
import { BookingService } from '../../services/booking.service';
import { BookingModalComponent } from '../booking-modal/booking-modal.component';

@Component({
  selector: 'app-my-bookings',
  standalone: true,
  imports: [CommonModule, RouterLink, BookingModalComponent],
  templateUrl: './my-bookings.component.html',
})
export class MyBookingsComponent implements OnInit {
  public bookings$!: Observable<Booking[] | null>;

  public pageTitle = 'My bookings';

  private refreshTrigger = new BehaviorSubject<void>(undefined);

  public WorkspaceType = WorkspaceType;

  public showDeleteModal = false;
  public bookingToDeleteId: number | null = null;
  public bookingToEdit: Booking | null = null;
  
  constructor(private bookingService: BookingService,
    private cd: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.bookings$ = this.refreshTrigger.pipe(
      switchMap(() => this.bookingService.getMyBookings()),
      tap((bookings) => {
        Promise.resolve().then(() => {
          if (bookings && bookings.length > 0) {
            this.pageTitle = 'My bookings on Green Coworking';
          } else {
            this.pageTitle = 'My bookings';
          }
          this.cd.detectChanges();
        });
      }),
      catchError((error) => {
        Promise.resolve().then(() => {
          this.pageTitle = 'My bookings';
          this.cd.detectChanges();
        });
        return of([]);
      })
    );
  }

  promptDelete(bookingId: number): void {
    this.bookingToDeleteId = bookingId;
    this.showDeleteModal = true;
  }

  confirmDelete(): void {
    if (this.bookingToDeleteId !== null) {
      this.bookingService.deleteBooking(this.bookingToDeleteId).subscribe({
        next: () => {
          this.refreshTrigger.next();
          this.cancelDelete();
        },
        error: (err) => {
          alert('Could not cancel the booking. Please try again.');
          this.cancelDelete();
        },
      });
    }
  }

  cancelDelete(): void {
    this.showDeleteModal = false;
    this.bookingToDeleteId = null;
  }

  promptEdit(bookingToEdit: Booking): void {
    this.bookingToEdit = bookingToEdit;
  }

  handleEditModalClose(refresh: boolean): void {
    if (refresh) {
      this.refreshTrigger.next();
    }
    this.bookingToEdit = null;
  }

  getDuration(start: string, end: string): string {
    const startDate = new Date(start);
    const endDate = new Date(end);
    const diffMs = endDate.getTime() - startDate.getTime();
    const diffHours = diffMs / (1000 * 60 * 60);

    if (diffHours < 24) {
      if (diffHours === 1) return '(1 hour)';
      return `(${diffHours.toFixed(0)} hours)`;
    } else {
      const diffDays = Math.ceil(diffMs / (1000 * 60 * 60 * 24)) + 1;
      if (diffDays === 1) return '(1 day)';
      return `(${diffDays} days)`;
    }
  }

  isSingleDayBooking(start: string, end: string): boolean {
    const startDate = new Date(start);
    const endDate = new Date(end);
    return startDate.toDateString() === endDate.toDateString();
  }
}
