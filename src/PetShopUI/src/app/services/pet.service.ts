import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

import { Pet } from '../interfaces/Pet';

const httpOption = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class PetService {
  private apiUrl: string = 'http://localhost:5000/api/Pets';
  selectedPet = new BehaviorSubject<Pet>({
    id: 0,
    name: '',
    reasonForTreatment: '',
    heathState: 0,
    accommodationNumber: 0
  });

  constructor(private http: HttpClient) { }

  addPet(pet: Pet): Observable<Pet> {
    return this.http.post<Pet>(this.apiUrl, pet, httpOption);
  }

  searchPet(petName: string): Observable<Pet[]> {
    const url = `${this.apiUrl}/?Name=${petName}`;
    return this.http.get<Pet[]>(url);
  }

  deletePet(petId: number): Observable<any> {
    const url = `${this.apiUrl}/${petId}`;
    return this.http.delete<Pet>(url);
  }

  updatePet(pet: Pet): Observable<any> {
    const url = `${this.apiUrl}/${pet.id}`;
    return this.http.put<Pet>(url, pet, httpOption);
  }
}
