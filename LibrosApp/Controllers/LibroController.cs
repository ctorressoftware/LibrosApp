using LibrosApp.Models.Repositories;
using LibrosApp.Models.Viewmodels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace LibrosApp.Controllers
{
    public class LibroController : Controller
    {
        LibroRepository _lrepo;

        public LibroController()
        {
            _lrepo = new LibroRepository();
        }

        public ActionResult Index()
        {
            return View(_lrepo.GetAll());
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var todosLosLibros = _lrepo.GetAll();

            //El error pasa cuando meto un string y no esta 
            //contenido en ninguna de las columnas anteriores 
            //a las de unidad y precio, al querer castear un 
            //string que no es un numero en uno da error

            try
            {
                var listaFiltrada = (from libro in todosLosLibros 
                                     where libro.Nombre.ToLower().StartsWith(collection[0].ToString().ToLower())
                                     || libro.ISBN.ToLower().StartsWith(collection[0].ToString().ToLower())
                                     || libro.Categoria.ToLower().StartsWith(collection[0].ToString().ToLower())
                                     || libro.Autor.ToLower().StartsWith(collection[0].ToString().ToLower())
                                     || libro.Unidades.ToString().StartsWith(collection[0].ToString())
                                     || libro.Precio.ToString().StartsWith(collection[0].ToString())
                                     select libro
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
            return View(_lrepo.FindById(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Id, ISBN, Nombre, Categoria, Autor, Unidades, Precio")] LibroViewModel libro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _lrepo.Create(libro);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(libro);
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(_lrepo.FindById(id));
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id, ISBN, Nombre, Categoria, Autor, Unidades, Precio")] LibroViewModel libro)
        {
            try
            {
                _lrepo.Update(libro);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View(_lrepo.FindById(id));
        }

        [HttpPost]
        public ActionResult Delete([Bind(Include = "Id, ISBN, Nombre, Categoria, Autor, Unidades, Precio")] LibroViewModel libro)
        {
            try
            {
                _lrepo.Delete(libro);

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