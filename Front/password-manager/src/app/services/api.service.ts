import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { map } from 'rxjs/operators';
import { catchError } from 'rxjs/internal/operators/catchError';
import { HttpHeaders, HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private httpClient: HttpClient) { }

  // Get call method
  get(url: string): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Cache-Control': 'no-cache',
        'Pragma': 'no-cache'
      })
    };

    return this.httpClient.get(url, httpOptions).pipe(
      map((response: any) => this.ReturnResponseData(response)),
      catchError(this.handleError)
    );
  }

  // Post call method
  post(url: string, model: any): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };

    return this.httpClient.post(url, model, httpOptions).pipe(
      map((response: any) => this.ReturnResponseData(response)),  // Ajout du return
      catchError(this.handleError)
    );
  }

  // Delete call method
  delete(url: string): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };

    return this.httpClient.delete(url, httpOptions).pipe(
      map((response: any) => this.ReturnResponseData(response)),
      catchError(this.handleError)
    );
  }


  private ReturnResponseData(response: any) {
    return response?.body ? response.body : response;
  }

  private handleError(error: any) {
    return throwError(error);
  }

  postFormUrlEncoded(url: string, model: any): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/x-www-form-urlencoded'
      })
    };

    return this.httpClient.post(url, model, httpOptions).pipe(
      map((response: any) => this.ReturnResponseData(response)),
      catchError(this.handleError)
    );
  }

}