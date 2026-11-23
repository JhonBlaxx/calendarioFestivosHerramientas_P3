import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API_URL } from '../config';
import { Festivo } from '../models';

@Injectable({ providedIn: 'root' })
export class FestivoService {
  private url = `${API_URL}/festivo`;

  constructor(private http: HttpClient) {}

  obtenerTodos(): Observable<Festivo[]> {
    return this.http.get<Festivo[]>(this.url);
  }

  obtenerPorPais(idPais: number): Observable<Festivo[]> {
    return this.http.get<Festivo[]>(`${this.url}/pais/${idPais}`);
  }

  crear(item: Festivo): Observable<Festivo> {
    return this.http.post<Festivo>(this.url, item);
  }

  actualizar(item: Festivo): Observable<unknown> {
    return this.http.put(`${this.url}/${item.id}`, item);
  }

  eliminar(id: number): Observable<unknown> {
    return this.http.delete(`${this.url}/${id}`);
  }
}
