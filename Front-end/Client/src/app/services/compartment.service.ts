import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Compartment } from '../interfaces/compartment';

@Injectable({
  providedIn: 'root'
})
export class CompartmentService {
  apiUrl: string = environment.apiUrl;
  
  constructor(private http: HttpClient) { }

  addCompartment=(data:Compartment): Observable<Compartment> => this.http.post<Compartment>(`${this.apiUrl}compartment/create`, data);
}
