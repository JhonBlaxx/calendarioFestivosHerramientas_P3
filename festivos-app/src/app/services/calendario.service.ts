import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API_URL } from '../config';
import { FestivoFecha } from '../models';

@Injectable({ providedIn: 'root' })
export class CalendarioService {
  private url = `${API_URL}/calendario`;

  constructor(private http: HttpClient) {}

  verificar(idPais: number, anio: number, mes: number, dia: number): Observable<string> {
    return this.http.get(`${this.url}/verificar/${idPais}/${anio}/${mes}/${dia}`, {
      responseType: 'text',
      headers: { Accept: 'text/plain' }
    });
  }

  listarFestivos(idPais: number, anio: number): Observable<FestivoFecha[]> {
    return this.http.get<FestivoFecha[]>(`${this.url}/festivos/${idPais}/${anio}`);
  }
}
