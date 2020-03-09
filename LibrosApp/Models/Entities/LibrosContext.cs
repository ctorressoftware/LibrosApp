using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LibrosApp.Models.Entities
{
    public class LibrosContext : DbContext
    {
        public LibrosContext() : base("LibrosDb")
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
    }
}