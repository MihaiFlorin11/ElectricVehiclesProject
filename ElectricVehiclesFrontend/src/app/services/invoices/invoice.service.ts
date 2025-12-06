import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Invoice } from 'src/app/entities/invoice';

@Injectable({
  providedIn: 'root'
})

export class InvoiceService {

  baseUrl = 'http://localhost:5000/api/';

  constructor(private httpClient: HttpClient) { }

  public getInvoices(): Observable<Invoice[]> {
    return this.httpClient.get<Invoice[]>(this.baseUrl + `invoices`);
  }

  public getInvoiceById(id: number): Observable<Invoice> {
    return this.httpClient.get<Invoice>(this.baseUrl + `invoices/${id}`);
  }

  public createInvoice(invoice: Invoice): Observable<Invoice> {
    return this.httpClient.post<Invoice>(this.baseUrl + `invoices`, invoice, { headers: new HttpHeaders({'Content-Type': 'application/json'})});
  }

  public updateInvoice(id: number, invoice: Invoice): Observable<Invoice> {
    return this.httpClient.put<Invoice>(this.baseUrl + `invoices/${id}`, invoice);
  }

  public deleteInvoice(id: number): Observable<Invoice> {
    return this.httpClient.delete<Invoice>(this.baseUrl + `invoices/${id}`);
  }
}
