import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http: HttpClient) { }

  obterCaminho(vi, vf) {
    return this.http.get<string[]>(`https://pucroutesapi.azurewebsites.net/api/Routes/${vi}/${vf}`);
  }
}
