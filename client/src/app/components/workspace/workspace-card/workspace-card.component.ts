import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  MyImage,
  RoomAvailability,
  Workspace,
} from '../../../models/workspace.model';

import { BookingModalComponent } from '../../booking-modal/booking-modal.component';

@Component({
  selector: 'app-workspace-card',
  standalone: true,
  imports: [CommonModule, BookingModalComponent],
  templateUrl: './workspace-card.component.html',
})
export class WorkspaceCardComponent implements OnInit {
  @Input({ required: true }) workspace!: Workspace;

  currentImage: MyImage | undefined;

  isBookingModalOpen = false;

  ngOnInit(): void {
    if (this.workspace.images?.length > 0) {
      this.currentImage = this.workspace.images[0];
    }
  }

  selectImage(image: MyImage): void {
    this.currentImage = image;
  }

  openBookingModal(): void {
    this.isBookingModalOpen = true;
  }

  onModalClose(didSave: boolean): void {
    this.isBookingModalOpen = false;
  }

  get isSingleDayBooking(): boolean {
    if (!this.workspace.booked) {
      return false;
    }
    const startDate = new Date(this.workspace.booked.startDate);
    const endDate = new Date(this.workspace.booked.endDate);

    return (
      startDate.getFullYear() === endDate.getFullYear() &&
      startDate.getMonth() === endDate.getMonth() &&
      startDate.getDate() === endDate.getDate()
    );
  }

  get isSingleAvailability(): boolean {
    return (
      this.workspace.capacityOptions?.[0]?.roomAvailabilities?.[0]
        ?.maxPeople === 0
    );
  }

  get singleAvailabilityCount(): number {
    return (
      this.workspace.capacityOptions?.[0]?.roomAvailabilities?.[0]
        ?.availableRooms ?? 0
    );
  }

  get capacityOptionsText(): string {
    const roomAvailabilities =
      this.workspace.capacityOptions?.[0]?.roomAvailabilities ?? [];
    return roomAvailabilities.map((r) => r.maxPeople).join(', ');
  }

  get roomAvailabilities(): RoomAvailability[] {
    return this.workspace.capacityOptions?.[0]?.roomAvailabilities ?? [];
  }
}
