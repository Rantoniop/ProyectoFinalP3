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

        /*---------------------------------------Proceso Citas--------------------------------------*/

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
                    Text = d.Id + " / " + d.Nombre + " / " + d.Cedula.ToString(),
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
                    Text = d.Id + " / " + d.Nombre + " / " + d.Cedula.ToString(),
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

        /*---------------------------------------Proceso Ingresos--------------------------------------*/
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
                    Text = d.Id + " / " + d.Nombre + " / " + d.Cedula.ToString(),
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
                    Text = d.Id + " / " + d.Nombre + " / " + d.Cedula.ToString(),
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

        // Editar ingreso
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

        /*---------------------------------------Proceso Altas--------------------------------------*/
        //Mostrar vista VistaAltas
        public ActionResult VistaAltas()
        {

            ViewBag.Altas = db.Altas.ToList();
            return View();
        }

        public ActionResult AgregarAlta()
        {

            //Llenar DropDownList de pacientes con id de la base de datos

            List<VistaAltasAModel> lstVA = null;
            lstVA =
                (from d in db.Ingresos
                 select new VistaAltasAModel
                 {
                     Id = d.Id


                 }).ToList();

            List<SelectListItem> itemsVA = lstVA.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Id.ToString(),
                    Value = d.Id.ToString(),
                    Selected = true
                };
            });

            ViewBag.itemsVA = itemsVA;

            return View();
        }

        //Ver Informacion del ingreso
        public ActionResult InfoAlta(Ingresos ingresos)
        {
            var DatosAlta = (from ingreso in db.Ingresos
                            join paciente in db.Pacientes on ingreso.PacientesId equals paciente.Id
                            join habitacion in db.Habitaciones on ingreso.HabitacionesId equals habitacion.Id
                            where ingreso.Id == ingresos.Id
                            select new
                            {
                                ingresoId = ingreso.Id,
                                fechaIngreso = ingreso.Fecha,
                                pacienteId = paciente.Id,
                                pacienteNombre = paciente.Nombre,
                                habitacionNumero = habitacion.Numero,
                                habitacionPP = habitacion.PrecioPorDia
                            });


            foreach (var datos in DatosAlta)
            {
                
                ViewBag.FechaIngreso = datos.fechaIngreso;
                ViewBag.PacienteId = datos.pacienteId;
                ViewBag.PacienteNombre = datos.pacienteNombre;
                ViewBag.HabitacionNumero = datos.habitacionNumero;

            }

            var DatosAltaLocal = DatosAlta.FirstOrDefault();

            ViewBag.DatosAlta = DatosAlta;

            TempData["IngresoId"] = DatosAltaLocal.ingresoId;
            TempData["HabitacionPP"] = DatosAltaLocal.habitacionPP;
            TempData["FechaIngreso"] = DatosAltaLocal.fechaIngreso;
            return View();
            
        }

        //Mostrar vista GuardarAlta
        public ActionResult GuardarAlta()
        {
            


            return View();
        }

        //Hacer operacion de Monto total t insertar agregar Alta
        [HttpPost]
        public ActionResult GuardarAlta(Altas altas)
        {
            DateTime FechaIngreso = DateTime.Parse(TempData["FechaIngreso"].ToString());
            DateTime FechaAlta = altas.Fecha;

            TimeSpan t = FechaAlta - FechaIngreso;
            double Dias = t.TotalDays;

            if (ModelState.IsValid)
            {
                try
                {

                    altas.IngresosId = int.Parse(TempData["IngresoId"].ToString());
                    altas.Monto = double.Parse(TempData["HabitacionPP"].ToString()) * Dias;

                    db.Altas.Add(altas);
                    db.SaveChanges();

                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }


                return RedirectToAction("VistaAltas");
            }

            return View(altas);
        }

        // Borrar Alta
        public ActionResult BorrarAlta(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Altas altas = db.Altas.Find(id);
            if (altas == null)
            {
                return HttpNotFound();
            }
            return View(altas);
        }

        // Confirmar Borrar Alta
        [HttpPost, ActionName("BorrarAlta")]
        public ActionResult ConfirmarBorrarAlta(int id)
        {
            Altas altas = db.Altas.Find(id);
            db.Altas.Remove(altas);
            db.SaveChanges();
            return RedirectToAction("VistaAltas");
        }

    }

}
