import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiClient {

  constructor(private http: HttpClient) { }

  public getProducts(): Observable<any> {
    return this.http.get(`${environment.GATEWAY}/inventory/products`);
  }

  public getProduct(productId: string): Observable<any> {
    return this.http.post(`${environment.GATEWAY}/inventory/products/${productId}`, {});
  }
}
