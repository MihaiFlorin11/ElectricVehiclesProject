import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Rental } from 'src/app/entities/rental';
import { RentalToDisplay } from 'src/app/entities/rentalToDisplay';

@Injectable({
  providedIn: 'root'
})

export class RentalService {

  baseUrl = 'http://localhost:5000/api/';

  constructor(private httpClient: HttpClient) { }

  public getRentals(): Observable<RentalToDisplay[]> {
    return this.httpClient.get<RentalToDisplay[]>(this.baseUrl + `rentals`);
  }

  public getRentalById(id: number): Observable<Rental> {
    return this.httpClient.get<Rental>(this.baseUrl + `rentals/${id}`);
  }

  public createRental(rental: Rental): Observable<Rental> {
    return this.httpClient.post<Rental>(this.baseUrl + `rentals`, rental, { headers: new HttpHeaders({'Content-Type': 'application/json'})});
  }

  public updateRental(id: number, rental: Rental): Observable<Rental> {
    return this.httpClient.put<Rental>(this.baseUrl + `rentals/${id}`, rental);
  }

  public deleteRental(id: number): Observable<Rental> {
    return this.httpClient.delete<Rental>(this.baseUrl + `rentals/${id}`);
  }
}

