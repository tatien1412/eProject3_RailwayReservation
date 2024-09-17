import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Station } from '../interfaces/station';

@Injectable({
  providedIn: 'root'
})
export class StationService {
  apiUrl:string = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getAll=(): Observable<Station[]> => this.http.get<Station[]>(`${this.apiUrl}station/getall`);

  getDetail = (stationID: number): Observable<Station> => 
    this.http.get<Station>(`${this.apiUrl}station/detail/${stationID}`);  

  addStation = (data: Station): Observable<Station> => this.http.post<Station>(`${this.apiUrl}station/create`, data);

  updateStation = (stationID: number, data:Station): Observable<void>=> this.http.put<void>(`${this.apiUrl}station/update/${stationID}`, data);

  deleteStation = (stationID:number): Observable<void> => this.http.delete<void>(`${this.apiUrl}station/delete/${stationID}`);

  getStations(page: number, pageSize: number): Observable<Station[]> {
    return this.http.get<Station[]>(`${this.apiUrl}/stations?page=${page}&pageSize=${pageSize}`);
  }
}
