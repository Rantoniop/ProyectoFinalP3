using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalP3.Models.ViewModels
{
    public class PModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }

    }
}
