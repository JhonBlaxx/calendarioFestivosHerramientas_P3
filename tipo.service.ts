import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API_URL } from '../config';
import { Tipo } from '../models';

@Injectable({ providedIn: 'root' })
export class TipoService {
  private url = `${API_URL}/tipo`;

  constructor(private http: HttpClient) {}

  obtenerTodos(): Observable<Tipo[]> {
    return this.http.get<Tipo[]>(this.url);
  }

  crear(item: Tipo): Observable<Tipo> {
    return this.http.post<Tipo>(this.url, item);
  }

  actualizar(item: Tipo): Observable<unknown> {
    return this.http.put(`${this.url}/${item.id}`, item);
  }

  eliminar(id: number): Observable<unknown> {
    return this.http.delete(`${this.url}/${id}`);
  }
}
