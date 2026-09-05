using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiFestivos.dominio
{
    [Table("Tipo")]
    public class Tipo
    {
        // Identificación
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        // Nombre del tipo
        [Required]
        [MaxLength(100)]
        [Column("Tipo")]
        public string Tipo1 { get; set; } = string.Empty;

        // Festivos relacionados
        public ICollection<Festivo> Festivos { get; set; } = new List<Festivo>();
    }
}