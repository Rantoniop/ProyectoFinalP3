using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinalP3.Models
{
    public class Pacientes
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public bool Asegurado { get; set; }
    }
}