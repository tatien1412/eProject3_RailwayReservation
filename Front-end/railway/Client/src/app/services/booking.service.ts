import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ScheduleSearch } from '../interfaces/schedulesearch';
import { Ticket } from '../interfaces/ticket';
import { Compartment } from '../interfaces/compartment';
import { Reservation } from '../interfaces/reservation';
import {  Availableseat } from '../interfaces/availableseat';
import { Seat } from '../interfaces/seat';

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
  
  getAvailableSeats =(TrainId:number):Observable<Availableseat> =>this.http.get<Availableseat>(`${this.apiUrl}Booking/AvailableSeat/${TrainId}`);

  
  updateseatstatus(
    TrainID: number, 
    CompartmentType: string, 
    TotalConfirmTicket: number
  ): Observable<void> {
    return this.http.put<void>(
      `${this.apiUrl}Booking/UpdateConfirmTicket/${TrainID}/${CompartmentType}/${TotalConfirmTicket}`, 
      {} // Truyền một body rỗng vì API không yêu cầu body
    );
  }
  }

