using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrosApp.Models.Viewmodels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(100, ErrorMessage = "El maximo son 100 caracteres.")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        [StringLength(100, ErrorMessage = "El maximo son 100 caracteres.")]
        public string Apellido { get; set; }

        [Required]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.DateTime)]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        [StringLength(100, ErrorMessage = "El maximo son 100 caracteres.")]
        public string Direccion { get; set; }

        [Required]
        [Display(Name = "Ciudad")]
        [StringLength(100, ErrorMessage = "El maximo son 100 caracteres.")]
        public string Ciudad { get; set; }

        [Required]
        [Display(Name = "País")]
        [StringLength(100, ErrorMessage = "El maximo son 100 caracteres.")]
        public string Pais { get; set; }

        [Display(Name = "Nombre")]
        public string NombreCompleto
        {
            get { return Nombre + " " + Apellido; }

            set { }
        }
    }
}