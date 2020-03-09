using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrosApp.Models.Viewmodels
{
    public class LibroViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El maximo son 100 caracteres.")]
        public string ISBN { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El maximo son 100 caracteres.")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Categoría")]
        [StringLength(100, ErrorMessage = "El maximo son 100 caracteres.")]
        public string Categoria { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El maximo son 100 caracteres.")]
        public string Autor { get; set; }

        [Required]
        [Range(0, 100000, ErrorMessage = "Las unidades solo pueden estar entre 0 y 100,000")]
        public int Unidades { get; set; }

        [Required]
        [Range(1, 100000, ErrorMessage = "El precio no puede ser menor a 1 ni mayor que 100,000.")]
        public double Precio { get; set; }

        public string NombreYUnidades
        {
            get
            {
                return Nombre + " - Total: " + Unidades + " unidades";
            }

            set
            {
                NombreYUnidades = "";
            }
        }
    }
}