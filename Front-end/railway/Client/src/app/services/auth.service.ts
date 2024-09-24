import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { LoginRequest } from '../interfaces/login-request';
import { map, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import {jwtDecode} from 'jwt-decode';
import { UserDetail } from '../interfaces/user-detail';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  apiUrl:string = environment.apiUrl;

  private tokenKey = 'token';

  constructor(private http:HttpClient) { }

  login(data: LoginRequest): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}account/login`, data).pipe(
      map((response) => {
        if (response && response.token && typeof localStorage !== 'undefined') {
          console.log('Token from server:', response.token); // Kiểm tra token nhận được từ server
          localStorage.setItem(this.tokenKey, response.token); // Lưu token vào localStorage
        } else {
          console.error('No token in response');
        }
        return response;
      })
    );
  }

  getDetail=(id: string): Observable<UserDetail> => 
    this.http.get<UserDetail>(`${this.apiUrl}users/detail/${id}`);

  getUserDetail = () => {
    const token = this.getToken();
    if (!token) return null; 
  
    try {
      const decodedToken: any = jwtDecode(token);  
      const userDetail = {
        id: decodedToken?.id || 'Unknown ID',  
        fullName: decodedToken?.name || 'Unknown User',  
        email: decodedToken?.email || 'Unknown Email',  
        role: decodedToken?.role || 'No Role'  
      }
  
      return userDetail;  
    } catch (error) {
      console.error("Error decoding token:", error);  
      return null;  
    }
  };

  isLoggedIn=():boolean => {
   const token = this.getToken();
   if(!token) return false;
   
   return !this.isTokenExpired();
  }

  private isTokenExpired() {
    const token = this.getToken();
    if(!token) return true;
    const decoded: any = jwtDecode(token);
    const isTokenExpired = Date.now() >= decoded['exp']! * 1000;
    if(isTokenExpired) this.logout();
    return isTokenExpired;
  }

  getRole=():string | null => {
    const token = this.getToken();
    if (!token) {
      return null;
    }
    try {
      const decodedToken: any = jwtDecode(token);
      console.log('Decoded Token:', decodedToken); 
      return decodedToken.role || null;
    } catch (error) {
      console.error('Error decoding token', error);
      return null;
    }
  }

  logout = ():void => {
    if (typeof localStorage !== 'undefined') {
      localStorage.removeItem(this.tokenKey);
    }
  }

  getAll=(): Observable<UserDetail[]> => this.http.get<UserDetail[]>(`${this.apiUrl}users/getall`);

  addUser = (data: UserDetail): Observable<UserDetail> => this.http.post<UserDetail>(`${this.apiUrl}users/create`, data);

  updateUser = (id:string, data:UserDetail): Observable<void>=> this.http.put<void>(`${this.apiUrl}users/update/${id}`, data);

  deleteUser = (id:string): Observable<void> => this.http.delete<void>(`${this.apiUrl}users/delete/${id}`);

  getUsers(page: number, pageSize: number): Observable<UserDetail[]> {
    return this.http.get<UserDetail[]>(`${this.apiUrl}/users?page=${page}&pageSize=${pageSize}`);
  }
  
  getToken = ():string|null => {
    if (typeof localStorage !== 'undefined') {
      return localStorage.getItem(this.tokenKey) || '';
    }
    else if (typeof sessionStorage !== 'undefined' && sessionStorage.getItem(this.tokenKey)) {
      return sessionStorage.getItem(this.tokenKey);
    }
    return null;
  }
}
