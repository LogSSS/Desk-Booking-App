import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, forkJoin, map, switchMap, tap } from 'rxjs';
import {
  Booking,
  BookingDTO,
  MyImageDTO,
  UpsertBooking,
} from '../models/booking.model';
import { environment } from '../../shared/constants/constants';

@Injectable({
  providedIn: 'root',
})
export class BookingService {
  private apiUrl = `${environment.apiUrl}/booking`;

  constructor(private http: HttpClient) {}

  getMyBookings(): Observable<Booking[]> {
    return this.http.get<BookingDTO[]>(this.apiUrl).pipe(
      map((bookings) =>
        bookings.map(
          (bookingDto) =>
            ({
              ...bookingDto,
              workspace: bookingDto.workspace
                ? {
                    ...bookingDto.workspace,
                    images: bookingDto.workspace.images.map((img) => ({
                      ...img,
                      link: img.link || 'https://via.placeholder.com/300x200',
                    })),
                  }
                : null,
            } as Booking)
        )
      )
    );
  }

  createBooking(bookingData: UpsertBooking): Observable<BookingDTO> {
    return this.http.post<BookingDTO>(this.apiUrl, bookingData);
  }

  updateBooking(id: number, bookingData: UpsertBooking): Observable<void> {
    return this.http.patch<void>(`${this.apiUrl}/${id}`, bookingData);
  }

  deleteBooking(id: number): Observable<void> {
    return this.http
      .delete<void>(`${this.apiUrl}/${id}`)
      .pipe(
        tap(() => console.log(`Booking with ID ${id} deleted successfully.`))
      );
  }
}
