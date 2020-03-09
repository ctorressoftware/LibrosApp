using System;
using System.Linq;
using System.Web.Mvc;
using LibrosApp.Models.Repositories;
using LibrosApp.Models.Viewmodels;

namespace LibrosApp.Controllers
{
    public class ClienteController : Controller
    {
        ClienteRepository _crepo;

        public ClienteController()
        {
            _crepo = new ClienteRepository();
        }

        public ActionResult Index()
        {
            return View(_crepo.GetAll());
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var todosLosClientes = _crepo.GetAll();

            try
            {
                var listaFiltrada = (from cliente in todosLosClientes
                                     where cliente.Nombre.ToLower().StartsWith(collection[0].ToString().ToLower())
                                     || cliente.Apellido.ToLower().StartsWith(collection[0].ToString().ToLower())
                                     || cliente.Email.ToLower().StartsWith(collection[0].ToString().ToLower())
                                     || cliente.Direccion.ToLower().StartsWith(collection[0].ToString().ToLower())
                                     || cliente.Ciudad.ToLower().StartsWith(collection[0].ToString().ToLower())
                                     || cliente.Pais.ToLower().StartsWith(collection[0].ToString().ToLower())
                                     || cliente.FechaNacimiento.Equals(collection[0].ToString().ToLower())
                                     select cliente
                                 ).ToList();

                ViewBag.Criterio = collection[0].ToString();

                return View(listaFiltrada);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
        }

        public ActionResult Details(int id)
        {
            return View(_crepo.FindById(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Id, Nombre, Apellido, FechaNacimiento, Email, Direccion, Ciudad, Pais")] ClienteViewModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _crepo.Create(cliente);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(cliente);
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(_crepo.FindById(id));
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id, Nombre, Apellido, FechaNacimiento, Email, Direccion, Ciudad, Pais")] ClienteViewModel cliente)
        {
            try
            {
                _crepo.Update(cliente);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View(_crepo.FindById(id));
        }

        [HttpPost]
        public ActionResult Delete([Bind(Include = "Id, Nombre, Apellido, FechaNacimiento, Email, Direccion, Ciudad, Pais")] ClienteViewModel cliente)
        {
            try
            {
                _crepo.Delete(cliente);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View();
            }
        }
    }
}
