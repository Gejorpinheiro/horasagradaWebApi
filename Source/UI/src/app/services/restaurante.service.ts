import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Restaurante } from "../models/Restaurante";

@Injectable({
  providedIn: 'root'
})
export class RestauranteService {

  private apiUrl = 'https://Localhost:5001/api/restaurante/';

  constructor(
    private http: HttpClient
  ) { }

  getRestaurante(idRestaurante: string) : Observable<Restaurante> {
    return this.http.get<Restaurante>(this.apiUrl + idRestaurante);
  }

  getRestaurantes() : Observable<Restaurante[]> {
    return this.http.get<Restaurante[]>(this.apiUrl);
  }

  updateRestaurante(restaurante: Restaurante) : Observable<Restaurante> {
    return this.http.put<Restaurante>(this.apiUrl, restaurante);
  }

  addRestaurante(restaurante: Restaurante) : Observable<Restaurante> {
    return this.http.post<Restaurante>(this.apiUrl, restaurante);
  }
  
  removeRestaurante(idRestaurante: string) : Observable<Restaurante> {
    return this.http.post<Restaurante>(this.apiUrl, idRestaurante);
  }
}
