import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class DailycashService {
  apiUrl:string = environment.apiUrl;
  constructor(private http: HttpClient) { }

}
