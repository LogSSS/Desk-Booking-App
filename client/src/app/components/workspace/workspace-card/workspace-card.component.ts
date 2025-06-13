import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  MyImage,
  RoomAvailability,
  Workspace,
} from '../../../models/workspace.model';

@Component({
  selector: 'app-workspace-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './workspace-card.component.html',
})
export class WorkspaceCardComponent implements OnInit {
  @Input({ required: true }) workspace!: Workspace;

  currentImage: MyImage | undefined;

  ngOnInit(): void {
    if (this.workspace.images?.length > 0) {
      this.currentImage = this.workspace.images[0];
    }
  }

  selectImage(image: MyImage): void {
    this.currentImage = image;
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
