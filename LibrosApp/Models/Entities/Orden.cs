using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrosApp.Models.Entities
{
    [Table("Orden")]
    public class Orden
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1, 100000)]
        public int Unidades { get; set; }

        [StringLength(200)]
        public string Descripcion { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [ForeignKey("Libro")]
        public int LibroId { get; set; }
        public Libro Libro { get; set; }
    }
}