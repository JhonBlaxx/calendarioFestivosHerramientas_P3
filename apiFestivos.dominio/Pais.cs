using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiFestivos.dominio
{
    [Table("Pais")]
    public class Pais
    {
        // Datos principales
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        [Column("Nombre")]
        public string Nombre { get; set; } = string.Empty;

        // Festivos asociados al país
        public ICollection<Festivo> Festivos { get; set; } = new List<Festivo>();
    }
}