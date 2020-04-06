using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Data.Entity;
using System.Web.Mvc;
using ProyectoFinalP3.Models;
using ProyectoFinalP3.Models.ViewModels;

namespace ProyectoFinalP3.Controllers
{
    public class ModuloProcesosController : Controller
    {
        
        private MCSystemContext db = new MCSystemContext();

        // GET: ModuloProcesos
        public ActionResult Index()
        {
            
            ViewBag.Citas = db.Citas.ToList();
            return View();
        }
        public ActionResult AgregarCita()
        {

            //Llenar DropDownList de pacientes con la base de datos

            List<PModel> lstP = null;
            lstP =
                (from d in db.Pacientes
                 select new PModel
                 {
                     Id = d.Id,
                     Nombre = d.Nombre,
                     Cedula = d.Cedula
                 }).ToList();

            List<SelectListItem> itemsP = lstP.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre + " / " + d.Cedula.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            ViewBag.itemsP = itemsP;

            //Llenar DropDownList de medicos con la base de datos

            List<MModel> lstM = null;
            lstM =
                (from d in db.Medicos
                 select new MModel
                 {
                     Id = d.Id,
                     Nombre = d.Nombre,
                     Especialidad = d.Especialidad
                 }).ToList();

            List<SelectListItem> itemsM = lstM.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Id + " / " + d.Nombre + " / " + d.Especialidad.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            ViewBag.itemsM = itemsM;

            

            return View();
        }

        [HttpPost]
        public ActionResult AgregarCita(Citas citas)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Citas.Add(citas);
                    db.SaveChanges();

                    

                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                
              
                return RedirectToAction("Index");
            }

            

            return View(citas);
        }


        public ActionResult EditarCita(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citas citas = db.Citas.Find(id);
            if (citas == null)
            {
                return HttpNotFound();

            }

            //Llenar DropDownList de pacientes con la base de datos

            List<PModel> lstP = null;
            lstP =
                (from d in db.Pacientes
                 select new PModel
                 {
                     Id = d.Id,
                     Nombre = d.Nombre,
                     Cedula = d.Cedula
                 }).ToList();

            List<SelectListItem> itemsP = lstP.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre + " / " + d.Cedula.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            ViewBag.itemsP = itemsP;

            //Llenar DropDownList de medicos con la base de datos

            List<MModel> lstM = null;
            lstM =
                (from d in db.Medicos
                 select new MModel
                 {
                     Id = d.Id,
                     Nombre = d.Nombre,
                     Especialidad = d.Especialidad
                 }).ToList();

            List<SelectListItem> itemsM = lstM.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Id + " / " + d.Nombre + " / " + d.Especialidad.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            ViewBag.itemsM = itemsM;

            return View(citas);
        }

        // POST: Citas/EditarCita/5
        
        [HttpPost]
        public ActionResult EditarCita(Citas citas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(citas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(citas);
        }

        // GET: Pacientes/Delete/5
        public ActionResult BorrarCita(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citas citas = db.Citas.Find(id);
            if (citas == null)
            {
                return HttpNotFound();
            }
            return View(citas);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("BorrarCita")]
        public ActionResult DeleteConfirmed(int id)
        {
            Citas citas = db.Citas.Find(id);
            db.Citas.Remove(citas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
