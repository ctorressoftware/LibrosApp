using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrosApp.Models.Entities
{
    [Table("Libro")]
    public class Libro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string ISBN { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Categoria { get; set; }

        [Required]
        [StringLength(100)]
        public string Autor { get; set; }

        [Required]
        [Range(0, 100000)]
        public int Unidades { get; set; }

        [Required]
        [Range(1, 100000)]
        public double Precio { get; set; }

        public ICollection<Orden> Ordenes { get; set; }
    }
}