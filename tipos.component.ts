import { Component, OnInit, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Observable } from 'rxjs';
import { Tipo } from '../models';
import { TipoService } from '../services/tipo.service';

@Component({
  selector: 'app-tipos',
  imports: [FormsModule],
  templateUrl: './tipos.component.html'
})
export class TiposComponent implements OnInit {
  tipos = signal<Tipo[]>([]);
  form = signal<Tipo>({ id: 0, nombre: '' });
  mensaje = signal('');
  error = signal('');

  constructor(private tipoService: TipoService) {}

  ngOnInit() {
    this.cargar();
  }

  cargar() {
    this.tipoService.obtenerTodos().subscribe({
      next: (lista) => this.tipos.set(lista),
      error: () => this.error.set('No se pudo conectar con la API. Verifique que esté en ejecución.')
    });
  }

  cambiarNombre(nombre: string) {
    this.form.update((f) => ({ ...f, nombre }));
  }

  editar(tipo: Tipo) {
    this.form.set({ ...tipo });
    this.mensaje.set('');
    this.error.set('');
  }

  cancelar() {
    this.form.set({ id: 0, nombre: '' });
  }

  guardar() {
    const tipo = this.form();
    const nuevo = tipo.id === 0;
    const peticion: Observable<unknown> = nuevo
      ? this.tipoService.crear(tipo)
      : this.tipoService.actualizar(tipo);

    peticion.subscribe({
      next: () => {
        this.mensaje.set(nuevo ? 'Tipo creado correctamente.' : 'Tipo actualizado correctamente.');
        this.error.set('');
        this.cancelar();
        this.cargar();
      },
      error: () => {
        this.mensaje.set('');
        this.error.set('No se pudo guardar el tipo.');
      }
    });
  }

  eliminar(tipo: Tipo) {
    if (!confirm(`¿Eliminar el tipo ${tipo.nombre}?`)) {
      return;
    }

    this.tipoService.eliminar(tipo.id).subscribe({
      next: () => {
        this.mensaje.set('Tipo eliminado correctamente.');
        this.error.set('');
        this.cargar();
      },
      error: () => {
        this.mensaje.set('');
        this.error.set('No se pudo eliminar el tipo. Puede tener festivos asociados.');
      }
    });
  }
}
