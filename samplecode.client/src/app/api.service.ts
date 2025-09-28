// src/app/api.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'https://localhost:44318'; // Replace with your actual API URL

  constructor(private http: HttpClient) { }

  getStockHistory(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/stockhistory?ticker=txn`);
  }

  getWeather(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/weatherforecast`);
  }
}
