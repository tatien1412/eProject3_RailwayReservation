import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ScheduleSearch } from '../interfaces/schedulesearch';
import { Ticket } from '../interfaces/ticket';
import { Compartment } from '../interfaces/compartment';
import { Reservation } from '../interfaces/reservation';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  apiUrl:string = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getAll(FromStationId: number,ToStationId: number, DateOfTravel: string, TotalPassenger: number): Observable<ScheduleSearch[]> {
    return this.http.get<ScheduleSearch[]>(
      `${this.apiUrl}Booking/GetTrains/${FromStationId}/${ToStationId}/${DateOfTravel}/${TotalPassenger}`
    );
  }
  createTicket=(data:Ticket): Observable<Ticket> => this.http.post<Ticket>(`${this.apiUrl}Ticket`,data);
  createReservation=(data:Reservation): Observable<Reservation> => this.http.post<Reservation>(`${this.apiUrl}Reservation`,data);
  getCompartmentData =(): Observable<Compartment[]> => this.http.get<Compartment[]>(`${this.apiUrl}Compartment/getall`);

  }

