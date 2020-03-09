using LibrosApp.Models.Entities;
using LibrosApp.Models.Repositories;
using LibrosApp.Models.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrosApp.Controllers
{
    public class OrdenController : Controller
    {
        OrdenRepository _orepo;
        LibroRepository _lrepo;
        ClienteRepository _crepo;

        public OrdenController()
        {
            _orepo = new OrdenRepository();
            _lrepo = new LibroRepository();
            _crepo = new ClienteRepository();
        }

        public ActionResult Index()
        {
            return View(_orepo.GetAll());
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var todasLasOrdenes = _orepo.GetAll();

            try
            {
                var listaFiltrada = (from orden in todasLasOrdenes
                                     where orden.Unidades.ToString().StartsWith(collection[0].ToString().ToLower())
                                     || orden.Descripcion.ToLower().StartsWith(collection[0].ToString().ToLower())
                                     || orden.Cliente.Nombre.ToLower().StartsWith(collection[0].ToString().ToLower())
                                     || orden.Libro.Nombre.ToLower().StartsWith(collection[0].ToString().ToLower())
                                     || orden.Monto.ToString().StartsWith(collection[0].ToString())
                                     select orden
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
            return View(_orepo.FindById(id));
        }

        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(_crepo.GetAll(), "Id", "NombreCompleto");
            ViewBag.LibroId = new SelectList(_lrepo.GetAll(), "Id", "NombreYUnidades");

            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Id, Unidades, Descripcion, ClienteId, LibroId")] OrdenViewModel orden)
        {
            ViewBag.ClienteId = new SelectList(_crepo.GetAll(), "Id", "NombreCompleto");
            ViewBag.LibroId = new SelectList(_lrepo.GetAll(), "Id", "NombreYUnidades");

            try
            {
                if (ModelState.IsValid)
                {
                    var db = new LibrosContext();

                    var libro = db.Libros.Find(orden.LibroId);

                    if (orden.Unidades <= libro.Unidades)
                    {
                        var libroModel = new LibroViewModel
                        {
                            Id = libro.Id,
                            ISBN = libro.ISBN,
                            Nombre = libro.Nombre,
                            Categoria = libro.Categoria,
                            Unidades = libro.Unidades - orden.Unidades,
                            Precio = libro.Precio,
                            Autor = libro.Autor,
                        };

                        _orepo.Create(orden);

                        _lrepo.Update(libroModel);

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Error = "Ingresó más unidades de las que habían en el inventario.";
                        return View(orden);
                    }
                }
                else
                {
                    return View(orden);
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.ClienteId = new SelectList(_crepo.GetAll(), "Id", "NombreCompleto", _orepo.FindById(id).ClienteId);
            ViewBag.LibroId = new SelectList(_lrepo.GetAll(), "Id", "Nombre", _orepo.FindById(id).LibroId);
            return View(_orepo.FindById(id));
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id, Unidades, Descripcion, ClienteId, LibroId")] OrdenViewModel orden)
        {
            try
            {
                _orepo.Update(orden);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View(_orepo.FindById(id));
        }

        [HttpPost]
        public ActionResult Delete([Bind(Include = "Id, Unidades, Descripcion, ClienteId, LibroId, Monto")] OrdenViewModel orden)
        {
            try
            {
                _orepo.Delete(orden);

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