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
            
            
            return View();
        }

        //Mostar vista VistaCitas
        public ActionResult VistaCitas()
        {

            ViewBag.Citas = db.Citas.ToList();
            return View();
        }

       
        //Mostrar vista AgregarCita
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

        //Agregar Cita
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
                
              
                return RedirectToAction("VistaCitas");
            }

            

            return View(citas);
        }

        //Mostrar vista EditarCita
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

        // Editar Cita
        
        [HttpPost]
        public ActionResult EditarCita(Citas citas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(citas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("VistaCitas");
            }
            return View(citas);
        }

        // Borrar Cita
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

        // Confirmar Borrar Cita
        [HttpPost, ActionName("BorrarCita")]
        public ActionResult ConfirmarBorrarCita(int id)
        {
            Citas citas = db.Citas.Find(id);
            db.Citas.Remove(citas);
            db.SaveChanges();
            return RedirectToAction("VistaCitas");
        }

        //Mostrar vista VistaIngresos
        public ActionResult VistaIngresos()
        {

            ViewBag.Ingresos = db.Ingresos.ToList();
            return View();
        }

        //Mostar vista IngresoPaciente
        public ActionResult IngresoPaciente()
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

            //Llenar DropDownList de Habitaciones con la base de datos

            List<HModel> lstH = null;
            lstH =
                (from d in db.Habitaciones
                 select new HModel
                 {
                     Id = d.Id,
                     Numero = d.Numero
                     
                 }).ToList();

            List<SelectListItem> itemsH = lstH.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Id + " / " + d.Numero,
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            ViewBag.itemsH = itemsH;



            return View();
        }

        //Ingresar Paciente
        [HttpPost]
        public ActionResult IngresoPaciente(Ingresos ingresos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Ingresos.Add(ingresos);
                    db.SaveChanges();



                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }


                return RedirectToAction("VistaIngresos");
            }



            return View(ingresos);
        }

        //Mostrar vista EditarIngreso
        public ActionResult EditarIngreso(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingresos ingresos = db.Ingresos.Find(id);
            if (ingresos == null)
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

            //Llenar DropDownList de Habitaciones con la base de datos

            List<HModel> lstH = null;
            lstH =
                (from d in db.Habitaciones
                 select new HModel
                 {
                     Id = d.Id,
                     Numero = d.Numero

                 }).ToList();

            List<SelectListItem> itemsH = lstH.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Id + " / " + d.Numero,
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            ViewBag.itemsH = itemsH;

            return View(ingresos);
        }

        // Editar Cita
        [HttpPost]
        public ActionResult EditarIngreso(Ingresos ingresos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingresos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("VistaIngresos");
            }
            return View(ingresos);
        }

        // Borrar Ingreso
        public ActionResult BorrarIngreso(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingresos ingresos = db.Ingresos.Find(id);
            if (ingresos == null)
            {
                return HttpNotFound();
            }
            return View(ingresos);
        }

        // Confirmar Borrar ingreso
        [HttpPost, ActionName("BorrarIngreso")]
        public ActionResult ConfirmarBorrarIngreso(int id)
        {
            Ingresos ingresos = db.Ingresos.Find(id);
            db.Ingresos.Remove(ingresos);
            db.SaveChanges();
            return RedirectToAction("VistaIngresos");
        }

    }

}
