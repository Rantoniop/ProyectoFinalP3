using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinalP3.Models
{
    public class Ingresos
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int PacientesId { get; set; }
        public int HabitacionesId { get; set; }
        public Pacientes Pacientes { get; set; }
        public Habitaciones Habitaciones { get; set; }

    }
}