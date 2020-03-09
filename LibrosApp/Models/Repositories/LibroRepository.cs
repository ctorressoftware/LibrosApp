using LibrosApp.Models.Entities;
using LibrosApp.Models.Viewmodels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibrosApp.Models.Repositories
{
    public class LibroRepository : IRepository<LibroViewModel>
    {
        public LibroViewModel FindById(int Id)
        {
            using (var db = new LibrosContext())
            {
                var libro = db.Libros.Find(Id);

                var model = new LibroViewModel
                {
                    Id = libro.Id,
                    ISBN = libro.ISBN,
                    Nombre = libro.Nombre,
                    Categoria = libro.Categoria,
                    Unidades = libro.Unidades,
                    Precio = libro.Precio,
                    Autor = libro.Autor
                };

                return model;
            }
        }

        public List<LibroViewModel> GetAll()
        {
            var listModel = new List<LibroViewModel>();

            using (var db = new LibrosContext())
            {
                foreach (var libro in db.Libros)
                {
                    var model = new LibroViewModel
                    {
                        Id = libro.Id,
                        ISBN = libro.ISBN,
                        Nombre = libro.Nombre,
                        Categoria = libro.Categoria,
                        Unidades = libro.Unidades,
                        Precio = libro.Precio,
                        Autor = libro.Autor
                    };

                    listModel.Add(model);
                }
            }

            return listModel;
        }

        public void Create(LibroViewModel model)
        {
            using (var db = new LibrosContext())
            {
                db.Libros.Add(new Libro
                {
                    Id = model.Id,
                    ISBN = model.ISBN,
                    Nombre = model.Nombre,
                    Categoria = model.Categoria,
                    Unidades = model.Unidades,
                    Precio = model.Precio,
                    Autor = model.Autor
                });

                db.SaveChanges();
            }
        }

        public void Delete(LibroViewModel model)
        {
            var libro = new Libro
            {
                Id = model.Id,
                ISBN = model.ISBN,
                Nombre = model.Nombre,
                Categoria = model.Categoria,
                Unidades = model.Unidades,
                Precio = model.Precio,
                Autor = model.Autor
            };

            using (var db = new LibrosContext())
            {
                db.Libros.Attach(libro);
                db.Entry(libro).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Update(LibroViewModel model)
        {
            var libro = new Libro
            {
                Id = model.Id,
                ISBN = model.ISBN,
                Nombre = model.Nombre,
                Categoria = model.Categoria,
                Unidades = model.Unidades,
                Precio = model.Precio,
                Autor = model.Autor
            };

            try
            {
                using (var db = new LibrosContext())
                {
                    db.Libros.Attach(libro);
                    db.Entry(libro).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string a = ex.Message;
                string b = "xd estos errores conio";
            }

            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}