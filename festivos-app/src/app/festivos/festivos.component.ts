import { Component, OnInit, computed, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Observable } from 'rxjs';
import { Festivo, Pais, Tipo } from '../models';
import { FestivoService } from '../services/festivo.service';
import { PaisService } from '../services/pais.service';
import { TipoService } from '../services/tipo.service';

@Component({
  selector: 'app-festivos',
  imports: [FormsModule],
  templateUrl: './festivos.component.html'
})
export class FestivosComponent implements OnInit {
  festivos = signal<Festivo[]>([]);
  paises = signal<Pais[]>([]);
  tipos = signal<Tipo[]>([]);
  filtroPais = signal(0);
  form = signal<Festivo>(this.festivoVacio());
  mensaje = signal('');
  error = signal('');

  festivosFiltrados = computed(() => {
    const idPais = this.filtroPais();
    if (idPais === 0) {
      return this.festivos();
    }
    return this.festivos().filter((f) => f.idPais === idPais);
  });

  constructor(
    private festivoService: FestivoService,
    private paisService: PaisService,
    private tipoService: TipoService
  ) {}

  ngOnInit() {
    this.cargarFestivos();
    this.paisService.obtenerTodos().subscribe({
      next: (lista) => this.paises.set(lista),
      error: () => this.mostrarErrorConexion()
    });
    this.tipoService.obtenerTodos().subscribe({
      next: (lista) => this.tipos.set(lista),
      error: () => this.mostrarErrorConexion()
    });
  }

  festivoVacio(): Festivo {
    return { id: 0, nombre: '', dia: 0, mes: 0, diasPascua: 0, idTipo: 0, idPais: 0 };
  }

  mostrarErrorConexion() {
    this.error.set('No se pudo conectar con la API. Verifique que esté en ejecución.');
  }

  cargarFestivos() {
    this.festivoService.obtenerTodos().subscribe({
      next: (lista) => this.festivos.set(lista),
      error: () => this.mostrarErrorConexion()
    });
  }

  cambiar<K extends keyof Festivo>(campo: K, valor: Festivo[K]) {
    this.form.update((f) => ({ ...f, [campo]: valor }));
  }

  formularioValido(): boolean {
    const f = this.form();
    return f.nombre.trim() !== '' && f.idPais !== 0 && f.idTipo !== 0;
  }

  nombrePais(id: number): string {
    return this.paises().find((p) => p.id === id)?.nombre ?? String(id);
  }

  nombreTipo(id: number): string {
    return this.tipos().find((t) => t.id === id)?.nombre ?? String(id);
  }

  editar(festivo: Festivo) {
    this.form.set({ ...festivo });
    this.mensaje.set('');
    this.error.set('');
  }

  cancelar() {
    this.form.set(this.festivoVacio());
  }

  guardar() {
    const festivo = this.form();
    const nuevo = festivo.id === 0;
    const peticion: Observable<unknown> = nuevo
      ? this.festivoService.crear(festivo)
      : this.festivoService.actualizar(festivo);

    peticion.subscribe({
      next: () => {
        this.mensaje.set(nuevo ? 'Festivo creado correctamente.' : 'Festivo actualizado correctamente.');
        this.error.set('');
        this.cancelar();
        this.cargarFestivos();
      },
      error: () => {
        this.mensaje.set('');
        this.error.set('No se pudo guardar el festivo.');
      }
    });
  }

  eliminar(festivo: Festivo) {
    if (!confirm(`¿Eliminar el festivo ${festivo.nombre}?`)) {
      return;
    }

    this.festivoService.eliminar(festivo.id).subscribe({
      next: () => {
        this.mensaje.set('Festivo eliminado correctamente.');
        this.error.set('');
        this.cargarFestivos();
      },
      error: () => {
        this.mensaje.set('');
        this.error.set('No se pudo eliminar el festivo.');
      }
    });
  }
}
