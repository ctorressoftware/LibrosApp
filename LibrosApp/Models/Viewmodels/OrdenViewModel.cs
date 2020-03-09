using LibrosApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrosApp.Models.Viewmodels
{
    public class OrdenViewModel
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 100000)]
        public int Unidades { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [Display(Name = "Libro")]
        public int LibroId { get; set; }
        public Libro Libro { get; set; }

        [StringLength(200)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Monto a pagar")]
        public double Monto {
            get
            {
                using (LibrosContext db = new LibrosContext())
                {
                    if(LibroId == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return Unidades * db.Libros.Find(LibroId).Precio;
                    }
                }
            }

            set
            {     
            }
        }
    }
}