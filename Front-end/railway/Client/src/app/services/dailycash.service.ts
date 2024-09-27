import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Dailycash } from '../interfaces/dailycash';
@Injectable({
  providedIn: 'root'
})
export class DailycashService {
  apiUrl:string = environment.apiUrl;
  constructor(private http: HttpClient) { }
  getcash = (date:string) :Observable<Dailycash> => this.http.get<Dailycash>(`${this.apiUrl}Booking/DailyCash/${date}`);
}
