import { DatePipe } from '@angular/common';
import { Component, OnInit, computed, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { FestivoFecha, Pais } from '../models';
import { CalendarioService } from '../services/calendario.service';
import { PaisService } from '../services/pais.service';

@Component({
  selector: 'app-consulta',
  imports: [FormsModule, DatePipe],
  templateUrl: './consulta.component.html'
})
export class ConsultaComponent implements OnInit {
  paises = signal<Pais[]>([]);
  idPais = signal(0);

  anio = signal<number | null>(new Date().getFullYear());
  mes = signal<number | null>(new Date().getMonth() + 1);
  dia = signal<number | null>(new Date().getDate());
  resultado = signal('');
  errorValidar = signal('');

  anioLista = signal<number | null>(new Date().getFullYear());
  festivos = signal<FestivoFecha[]>([]);
  listaConsultada = signal(false);
  errorLista = signal('');

  claseResultado = computed(() => {
    const texto = this.resultado();
    if (texto === 'Es Festivo') {
      return 'ok';
    }
    if (texto === 'No es festivo') {
      return 'neutro';
    }
    return 'error';
  });

  constructor(
    private calendarioService: CalendarioService,
    private paisService: PaisService
  ) {}

  ngOnInit() {
    this.paisService.obtenerTodos().subscribe({
      next: (lista) => {
        this.paises.set(lista);
        if (lista.length > 0) {
          this.idPais.set(lista[0].id);
        }
      },
      error: () => this.errorValidar.set('No se pudo conectar con la API. Verifique que esté en ejecución.')
    });
  }

  validar() {
    this.resultado.set('');
    this.errorValidar.set('');

    const anio = this.anio();
    const mes = this.mes();
    const dia = this.dia();
    if (this.idPais() === 0 || anio === null || mes === null || dia === null) {
      this.errorValidar.set('Seleccione un país e ingrese el año, el mes y el día.');
      return;
    }

    this.calendarioService.verificar(this.idPais(), anio, mes, dia).subscribe({
      next: (texto) => this.resultado.set(texto.replace(/"/g, '').trim()),
      error: () => this.errorValidar.set('No se pudo realizar la consulta. Verifique los datos y la API.')
    });
  }

  listar() {
    this.festivos.set([]);
    this.listaConsultada.set(false);
    this.errorLista.set('');

    const anio = this.anioLista();
    if (this.idPais() === 0 || anio === null) {
      this.errorLista.set('Seleccione un país e ingrese el año.');
      return;
    }

    this.calendarioService.listarFestivos(this.idPais(), anio).subscribe({
      next: (lista) => {
        this.festivos.set(lista);
        this.listaConsultada.set(true);
      },
      error: () => this.errorLista.set('No se pudo obtener la lista de festivos.')
    });
  }
}
