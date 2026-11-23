import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API_URL } from '../config';
import { Pais } from '../models';

@Injectable({ providedIn: 'root' })
export class PaisService {
  private url = `${API_URL}/pais`;

  constructor(private http: HttpClient) {}

  obtenerTodos(): Observable<Pais[]> {
    return this.http.get<Pais[]>(this.url);
  }

  crear(item: Pais): Observable<Pais> {
    return this.http.post<Pais>(this.url, item);
  }

  actualizar(item: Pais): Observable<unknown> {
    return this.http.put(`${this.url}/${item.id}`, item);
  }

  eliminar(id: number): Observable<unknown> {
    return this.http.delete(`${this.url}/${id}`);
  }
}
