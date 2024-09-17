import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Schedule } from '../interfaces/schedule';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ScheduleService {

  apiUrl: string = environment.apiUrl;
  
  constructor(private http: HttpClient) { }

  addSchedule=(data:Schedule): Observable<Schedule> => this.http.post<Schedule>(`${this.apiUrl}schedule/create`, data);
}
