using LibrosApp.Models.Entities;
using LibrosApp.Models.Viewmodels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibrosApp.Models.Repositories
{
    public class OrdenRepository : IRepository<OrdenViewModel>
    {
        public OrdenViewModel FindById(int Id)
        {
            using (var db = new LibrosContext())
            {
                var ordenes = db.Ordenes.Include(x => x.Cliente).Include(x => x.Libro).ToList();

                var orden = ordenes.Find(x => x.Id == Id);

                var model = new OrdenViewModel
                {
                    Id = orden.Id,
                    Unidades = orden.Unidades,
                    Descripcion = orden.Descripcion,
                    ClienteId = orden.ClienteId,
                    LibroId = orden.LibroId,
                    Cliente = orden.Cliente,
                    Libro = orden.Libro
                };

                return model;
            }
        }

        public List<OrdenViewModel> GetAll()
        {
            var listModel = new List<OrdenViewModel>();

            using (var db = new LibrosContext())
            {
                var listaOrdenes = db.Ordenes.Include(x => x.Cliente).Include(x => x.Libro);

                foreach (var orden in listaOrdenes.ToList())
                {
                    var model = new OrdenViewModel
                    {
                        Id = orden.Id,
                        Unidades = orden.Unidades,
                        Descripcion = orden.Descripcion,
                        ClienteId = orden.ClienteId,
                        LibroId = orden.LibroId,
                        Cliente = orden.Cliente,
                        Libro = orden.Libro
                    };

                    listModel.Add(model);
                }
            }

            return listModel;
        }

        public void Create(OrdenViewModel model)
        {
            using (var db = new LibrosContext())
            {
                db.Ordenes.Add(new Orden
                {
                    Id = model.Id,
                    Unidades = model.Unidades,
                    Descripcion = model.Descripcion,
                    ClienteId = model.ClienteId,
                    LibroId = model.LibroId
                });

                db.SaveChanges();
            }
        }

        public void Delete(OrdenViewModel model)
        {
            var orden = new Orden
            {
                Id = model.Id,
                Unidades = model.Unidades,
                Descripcion = model.Descripcion,
                ClienteId = model.ClienteId,
                LibroId = model.LibroId
            };

            using (var db = new LibrosContext())
            {
                db.Ordenes.Attach(orden);
                db.Entry(orden).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Update(OrdenViewModel model)
        {
            var orden = new Orden
            {
                Id = model.Id,
                Unidades = model.Unidades,
                Descripcion = model.Descripcion,
                ClienteId = model.ClienteId,
                LibroId = model.LibroId
            };

            using (var db = new LibrosContext())
            {
                db.Ordenes.Attach(orden);
                db.Entry(orden).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}