import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Vehicle } from 'src/app/entities/vehicle';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  baseUrl = 'http://localhost:5000/api/';

  constructor(private httpClient: HttpClient) { }

  public getVehicles(): Observable<Vehicle[]> {
    return this.httpClient.get<Vehicle[]>(this.baseUrl + `vehicles`);
  }

  public getVehicleById(id: number): Observable<Vehicle> {
    return this.httpClient.get<Vehicle>(this.baseUrl + `vehicles/${id}`);
  }

  public createVehicle(vehicle: Vehicle): Observable<Vehicle> {
    return this.httpClient.post<Vehicle>(this.baseUrl + `vehicles`, vehicle, { headers: new HttpHeaders({'Content-Type': 'application/json'})});
  }

  public updateVehicle(id: number, vehicle: Vehicle): Observable<Vehicle> {
    return this.httpClient.put<Vehicle>(this.baseUrl + `vehicles/${id}`, vehicle);
  }

  public deleteVehicle(id: number): Observable<Vehicle> {
    return this.httpClient.delete<Vehicle>(this.baseUrl + `vehicles/${id}`);
  }
}
