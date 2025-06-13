import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';
import { Workspace } from '../../models/workspace.model';
import { WorkspaceCardComponent } from './workspace-card/workspace-card.component';
import { WorkspaceService } from '../../services/workspace.service';

@Component({
  selector: 'app-workspaces',
  standalone: true,
  imports: [CommonModule, WorkspaceCardComponent],
  templateUrl: './workspace.component.html',
})
export class WorkspaceComponent implements OnInit {
  workspaces$!: Observable<Workspace[]>;

  constructor(private workspaceService: WorkspaceService) {}

  ngOnInit(): void {
    this.workspaces$ = this.workspaceService.getWorkspaces();
  }
}
