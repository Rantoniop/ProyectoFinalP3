using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinalP3.Models
{
    public class Altas
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public int IngresosId { get; set; }
        public Ingresos Ingresos { get; set; }
    }
}