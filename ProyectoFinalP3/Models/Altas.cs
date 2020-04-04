using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalP3.Models
{
    public class Altas
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La fecha de Alta es requerida.")]
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public int IngresosId { get; set; }
        public Ingresos Ingresos { get; set; }
    }
}