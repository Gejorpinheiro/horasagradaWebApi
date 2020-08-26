import { Injectable, resolveForwardRef } from '@angular/core';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { Usuario } from '../models/Usuario';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  private usuarioLogadoSource = new BehaviorSubject<Usuario>(null);
  private apiUrl = 'https://Localhost:5001/api/usuario/';
  usuarioLogado$ = this.usuarioLogadoSource.asObservable();
  usuario: Usuario;

  constructor(
    private http: HttpClient
  ) {}

  getUsuario(usuario: string) : Observable<Usuario> {
    return this.http.get<Usuario>(this.apiUrl + usuario);
  }

  postUsuario(usuario: string) : Observable<Usuario> {
    return this.http.post<Usuario>(this.apiUrl, { nome: usuario });
  }

  public salvaUsuarioLogado(value) {
    this.usuario = value;
    this.usuarioLogadoSource.next(this.usuario);
  }
}
