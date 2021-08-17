import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ICompany } from '../models/ICompany';


@Injectable({
  providedIn: 'root'
})
export class ApiControllerService {

  private urlBase: string = "https://localhost:44375/";

  private headers: HttpHeaders;
  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  GetAllType() {
    return this.http.get(this.urlBase + 'api/ApiCompany', { headers: this.headers });
  }

  searchIdentifiactionCompany(id : any) {
    return this.http.get(this.urlBase + 'api/ApiCompany/' + id, { headers: this.headers });

  }

  updateCompany(CompanyUpodate: ICompany) {
    return this.http.post(this.urlBase + 'api/ApiCompany', CompanyUpodate, { headers: this.headers });

  }
}
