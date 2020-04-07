using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using ProyectoFinalP3.Models;
using ProyectoFinalP3.Models.ViewModels;

namespace ProyectoFinalP3.Controllers
{
    public class ModuloConsultasController : Controller
    {
        private MCSystemContext db = new MCSystemContext();


        // GET: ModuloConsultas
        public ActionResult Index()
        {

            return View();
        }

        //Mostar vista VistaPacientes
        public ActionResult VistaPacientes()
        {



            ViewBag.Pacientes = db.Pacientes.ToList();
            return View();
        }

        
    }
}