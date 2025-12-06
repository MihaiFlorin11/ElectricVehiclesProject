import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../../entities/user';

@Injectable({
  providedIn: 'root'
})

export class UserService {

  baseUrl = 'http://localhost:5000/api/';

  constructor(private httpClient: HttpClient) { }

  public getUsers(): Observable<User[]> {
    return this.httpClient.get<User[]>(this.baseUrl + `users`);
  }

  public getUserById(id: number): Observable<User> {
    return this.httpClient.get<User>(this.baseUrl + `users/${id}`);
  }

  public createUser(user: User): Observable<User> {
    return this.httpClient.post<User>(this.baseUrl + `users`, user, { headers: new HttpHeaders({'Content-Type': 'application/json'})});
  }

  public registerUser(user: User): Observable<User> {
    return this.httpClient.post<User>(this.baseUrl + `users/register`, user);
  }

  public loginUser(user: User): Observable<User> {
    return this.httpClient.post<User>(this.baseUrl + `users/login`, user);
  }

  public updateUser(id: number, user: User): Observable<User> {
    return this.httpClient.put<User>(this.baseUrl + `users/${id}`, user);
  }

  public deleteUser(id: number): Observable<User> {
    return this.httpClient.delete<User>(this.baseUrl + `users/${id}`);
  }
}
