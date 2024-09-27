import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Seat } from '../interfaces/seat';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SeatService {
    apiUrl:string = environment.apiUrl;
   constructor(private http: HttpClient) { }
   getDetail = (seatID: number): Observable<Seat> => 
    this.http.get<Seat>(`${this.apiUrl}seat/detail/${seatID}`);  
}
