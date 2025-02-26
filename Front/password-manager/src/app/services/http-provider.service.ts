import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { ApiService } from './api.service';
import { passwordForm } from '../components/add-password/add-password.component';
import { applicationForm } from '../components/application-list/application-list.component';

const apiUrl = environment.apiUrl;

const httpLink = {
  passwords: `${apiUrl}password`,
  applications: `${apiUrl}application`,
}

@Injectable({
  providedIn: 'root'
})

export class HttpProviderService {
  constructor(private apiService: ApiService) { }

  public getPasswords() : Observable<any> {
    return this.apiService.get(httpLink.passwords)
  }

  public savePassword(model: passwordForm): Observable<any> {
    return this.apiService.post(httpLink.passwords, model)
  }

  public deletePassword(id: any): Observable<any> {
    return this.apiService.delete(`${httpLink.passwords}/${id}`);
  }

  public getApplications() : Observable<any> {
    return this.apiService.get(httpLink.applications)
  }

  public saveApplication(model: applicationForm): Observable<any> {
    return this.apiService.post(httpLink.applications, model)
  }
}
