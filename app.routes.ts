import { Routes } from '@angular/router';
import { ConsultaComponent } from './consulta/consulta.component';
import { FestivosComponent } from './festivos/festivos.component';
import { PaisesComponent } from './paises/paises.component';
import { TiposComponent } from './tipos/tipos.component';

export const routes: Routes = [
  { path: '', redirectTo: 'consulta', pathMatch: 'full' },
  { path: 'consulta', component: ConsultaComponent, title: 'Consulta de festivos' },
  { path: 'festivos', component: FestivosComponent, title: 'Festivos' },
  { path: 'paises', component: PaisesComponent, title: 'Países' },
  { path: 'tipos', component: TiposComponent, title: 'Tipos de festivo' },
  { path: '**', redirectTo: 'consulta' }
];
