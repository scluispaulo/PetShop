import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Accommodation } from '../interfaces/Accommodation';

@Injectable({
  providedIn: 'root'
})
export class AccommodationService {
  private apiUrl: string = 'http://localhost:5000/accommodation';

  constructor(private http: HttpClient) { }
  
  getFreeAccommodation(): Observable<Accommodation[]> {
    const url = `${this.apiUrl}/getFreeAccommodation`;
    return this.http.get<Accommodation[]>(url);
  }
}
