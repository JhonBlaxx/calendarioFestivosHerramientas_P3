import { Component, OnInit, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Observable } from 'rxjs';
import { Pais } from '../models';
import { PaisService } from '../services/pais.service';

@Component({
  selector: 'app-paises',
  imports: [FormsModule],
  templateUrl: './paises.component.html'
})
export class PaisesComponent implements OnInit {
  paises = signal<Pais[]>([]);
  form = signal<Pais>({ id: 0, nombre: '' });
  mensaje = signal('');
  error = signal('');

  constructor(private paisService: PaisService) {}

  ngOnInit() {
    this.cargar();
  }

  cargar() {
    this.paisService.obtenerTodos().subscribe({
      next: (lista) => this.paises.set(lista),
      error: () => this.error.set('No se pudo conectar con la API. Verifique que esté en ejecución.')
    });
  }

  cambiarNombre(nombre: string) {
    this.form.update((f) => ({ ...f, nombre }));
  }

  editar(pais: Pais) {
    this.form.set({ ...pais });
    this.mensaje.set('');
    this.error.set('');
  }

  cancelar() {
    this.form.set({ id: 0, nombre: '' });
  }

  guardar() {
    const pais = this.form();
    const nuevo = pais.id === 0;
    const peticion: Observable<unknown> = nuevo
      ? this.paisService.crear(pais)
      : this.paisService.actualizar(pais);

    peticion.subscribe({
      next: () => {
        this.mensaje.set(nuevo ? 'País creado correctamente.' : 'País actualizado correctamente.');
        this.error.set('');
        this.cancelar();
        this.cargar();
      },
      error: () => {
        this.mensaje.set('');
        this.error.set('No se pudo guardar el país.');
      }
    });
  }

  eliminar(pais: Pais) {
    if (!confirm(`¿Eliminar el país ${pais.nombre}?`)) {
      return;
    }

    this.paisService.eliminar(pais.id).subscribe({
      next: () => {
        this.mensaje.set('País eliminado correctamente.');
        this.error.set('');
        this.cargar();
      },
      error: () => {
        this.mensaje.set('');
        this.error.set('No se pudo eliminar el país. Puede tener festivos asociados.');
      }
    });
  }
}
