import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Workspace } from '../models/workspace.model';
import { environment } from '../../shared/constants/constants';

@Injectable({
  providedIn: 'root',
})
export class WorkspaceService {
  private workspacesUrl = `${environment.apiUrl}/workspaces`;

  constructor(private http: HttpClient) {}

  getWorkspaces(): Observable<Workspace[]> {
    return this.http.get<Workspace[]>(this.workspacesUrl).pipe(
      catchError(this.handleError<Workspace[]>('getWorkspaces', []))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      return of(result as T);
    };
  }
}
