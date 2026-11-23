export interface Pais {
  id: number;
  nombre: string;
}

export interface Tipo {
  id: number;
  nombre: string;
}

export interface Festivo {
  id: number;
  nombre: string;
  dia: number;
  mes: number;
  diasPascua: number;
  idTipo: number;
  idPais: number;
}

export interface FestivoFecha {
  festivo: string;
  fecha: string;
}
