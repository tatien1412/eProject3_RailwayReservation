import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Ticket } from '../interfaces/ticket';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class TicketService {
  apiUrl:string = environment.apiUrl;
  constructor(private http: HttpClient) { }
  getDetail = (PnrNo: number): Observable<Ticket> => 
    this.http.get<Ticket>(`${this.apiUrl}Ticket/${PnrNo}`);  
  deleteTicket =(PnrNo: number): Observable<Ticket> =>
    this.http.delete<Ticket>(`${this.apiUrl}Ticket/${PnrNo}`);
}
