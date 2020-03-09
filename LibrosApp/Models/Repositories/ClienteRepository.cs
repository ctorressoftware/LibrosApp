using LibrosApp.Models.Entities;
using LibrosApp.Models.Viewmodels;
using System.Collections.Generic;
using System.Data.Entity;

namespace LibrosApp.Models.Repositories
{
    public class ClienteRepository : IRepository<ClienteViewModel>
    {
        public ClienteViewModel FindById(int Id)
        {
            using (var db = new LibrosContext())
            {
                var cliente = db.Clientes.Find(Id);

                var model = new ClienteViewModel
                {
                    Id = cliente.Id,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Email = cliente.Email,
                    FechaNacimiento = cliente.FechaNacimiento,
                    Direccion = cliente.Direccion,
                    Ciudad = cliente.Ciudad,
                    Pais = cliente.Pais
                };

                return model;
            }
        }

        public List<ClienteViewModel> GetAll()
        {
            var listModel = new List<ClienteViewModel>();

            using (var db = new LibrosContext())
            {
                foreach (var cliente in db.Clientes)
                {
                    var model = new ClienteViewModel
                    {
                        Id = cliente.Id,
                        Nombre = cliente.Nombre,
                        Apellido = cliente.Apellido,
                        Email = cliente.Email,
                        FechaNacimiento = cliente.FechaNacimiento,
                        Direccion = cliente.Direccion,
                        Ciudad = cliente.Ciudad,
                        Pais = cliente.Pais
                    };

                    listModel.Add(model);
                }
            }

            return listModel;
        }

        public void Create(ClienteViewModel model)
        {
            using (var db = new LibrosContext())
            {
                db.Clientes.Add(new Cliente
                {
                    Id = model.Id,
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    Email = model.Email,
                    FechaNacimiento = model.FechaNacimiento,
                    Direccion = model.Direccion,
                    Ciudad = model.Ciudad,
                    Pais = model.Pais
                });

                db.SaveChanges();
            }
        }

        public void Delete(ClienteViewModel model)
        {
            var cliente = new Cliente
            {
                Id = model.Id,
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                Email = model.Email,
                FechaNacimiento = model.FechaNacimiento,
                Direccion = model.Direccion,
                Ciudad = model.Ciudad,
                Pais = model.Pais
            };

            using (var db = new LibrosContext())
            {
                db.Clientes.Attach(cliente);
                db.Entry(cliente).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Update(ClienteViewModel model)
        {
            var cliente = new Cliente
            {
                Id = model.Id,
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                Email = model.Email,
                FechaNacimiento = model.FechaNacimiento,
                Direccion = model.Direccion,
                Ciudad = model.Ciudad,
                Pais = model.Pais
            };

            using (var db = new LibrosContext())
            {
                db.Clientes.Attach(cliente);
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Dispose()
        {
        }
    }
}