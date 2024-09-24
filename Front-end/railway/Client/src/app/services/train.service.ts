import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Train } from '../interfaces/train'; // Import interface Train

@Injectable({
  providedIn: 'root'
})
export class TrainService {
  apiUrl: string = environment.apiUrl;
  
  constructor(private http: HttpClient) { }

  getAll = (): Observable<Train[]> => this.http.get<Train[]>(`${this.apiUrl}train/getall`);

  getDetail = (trainID: number): Observable<Train> => 
    this.http.get<Train>(`${this.apiUrl}train/detail/${trainID}`);  

  addTrain = (data: Train): Observable<Train> => this.http.post<Train>(`${this.apiUrl}train/create`, data);

  updateTrain = (trainID: number, data: Train): Observable<void> => 
    this.http.put<void>(`${this.apiUrl}train/update/${trainID}`, data);

  deleteTrain = (trainID: number): Observable<void> => 
    this.http.delete<void>(`${this.apiUrl}train/delete/${trainID}`);

  getTrains(page: number, pageSize: number): Observable<Train[]> {
    return this.http.get<Train[]>(`${this.apiUrl}/trains?page=${page}&pageSize=${pageSize}`);
  }
  updateNumberOfCompartments(command: { trainID: number, numberOfCompartments: number }): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}train/updatecompartment/${command.trainID}`, command);
  }
}
