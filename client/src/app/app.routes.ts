import { Routes } from '@angular/router';
import { WorkspaceComponent } from './components/workspace/workspace.component';
import { MyBookingsComponent } from './components/my-bookings/my-bookings.component';

export const routes: Routes = [
  { path: 'workspace', component: WorkspaceComponent },
  { path: 'my', component: MyBookingsComponent },
  { path: '', redirectTo: '/workspace', pathMatch: 'full' },
];
