using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiFestivos.dominio
{
    [Table("Festivo")]
    public class Festivo
    {
        // Identificador
        [Key]
        [Column("Id")]
        public int Id { get; set; }


        // Información del festivo
        [Required]
        [MaxLength(100)]
        [Column("Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [Column("Dia")]
        public int Dia { get; set; }

        [Required]
        [Column("Mes")]
        public int Mes { get; set; }

        [Required]
        [Column("DiasPascua")]
        public int DiasPascua { get; set; }


        // Relación con Tipo
        [Required]
        [Column("IdTipo")]
        [ForeignKey(nameof(Tipo))]
        public int IdTipo { get; set; }

        public Tipo Tipo { get; set; } = null!;


        // Relación con País
        [Required]
        [Column("IdPais")]
        [ForeignKey(nameof(Pais))]
        public int IdPais { get; set; }

        public Pais Pais { get; set; } = null!;
    }
}