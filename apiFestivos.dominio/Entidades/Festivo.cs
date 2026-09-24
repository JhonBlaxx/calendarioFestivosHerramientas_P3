namespace apiFestivos.dominio.Entidades
{
    public class Festivo
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int DiasPascua { get; set; }
        public int IdTipo { get; set; }
        public int IdPais { get; set; }
    }
}
