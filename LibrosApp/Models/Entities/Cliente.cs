using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrosApp.Models.Entities
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(100)]
        public string Ciudad { get; set; }

        [Required]
        [StringLength(100)]
        public string Pais { get; set; }

        public ICollection<Orden> Ordenes { get; set; }
    }
}