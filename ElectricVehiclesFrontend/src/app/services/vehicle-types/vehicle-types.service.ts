import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Vehicle } from 'src/app/entities/vehicle';
import { Observable } from 'rxjs';
import { VehicleTypes } from 'src/app/entities/vehicle-types';

@Injectable({
  providedIn: 'root'
})
export class VehicleTypesService {

  baseUrl = 'http://localhost:5000/api/';

  constructor(private httpClient: HttpClient) { }

  public getVehicleTypes(): Observable<VehicleTypes[]> {
    return this.httpClient.get<VehicleTypes[]>(this.baseUrl + `vehicleTypes`);
  }

  public getVehicleTypeById(id: number): Observable<VehicleTypes> {
    return this.httpClient.get<VehicleTypes>(this.baseUrl + `vehicleTypes/${id}`);
  }

  public createVehicleType(vehicleTypes: VehicleTypes): Observable<VehicleTypes> {
    return this.httpClient.post<VehicleTypes>(this.baseUrl + `vehicleTypes`, vehicleTypes, { headers: new HttpHeaders({'Content-Type': 'application/json'})});
  }

  public updateVehicleType(id: number, vehicleTypes: VehicleTypes): Observable<VehicleTypes> {
    return this.httpClient.put<VehicleTypes>(this.baseUrl + `vehicleTypes/${id}`, vehicleTypes);
  }

  public deleteVehicleType(id: number): Observable<VehicleTypes> {
    return this.httpClient.delete<VehicleTypes>(this.baseUrl + `vehicleTypes/${id}`);
  }
}
