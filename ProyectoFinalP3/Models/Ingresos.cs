using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalP3.Models
{
    public class Ingresos
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La fecha de ingreso es requerida.")]
        public DateTime Fecha { get; set; }
        public int PacientesId { get; set; }
        public int HabitacionesId { get; set; }
        public Pacientes Pacientes { get; set; }
        public Habitaciones Habitaciones { get; set; }

    }
}