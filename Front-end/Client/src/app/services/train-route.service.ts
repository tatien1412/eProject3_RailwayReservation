import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TrainRoute } from '../interfaces/train-route';

@Injectable({
  providedIn: 'root'
})
export class TrainRouteService {
  apiUrl: string = environment.apiUrl;
  
  constructor(private http: HttpClient) { }

  getAllTrainRoutes(): Observable<TrainRoute[]> {
    return this.http.get<TrainRoute[]>(`${this.apiUrl}trainRoute/getall`)
  }
}
