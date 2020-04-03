using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinalP3.Models
{
    public class Citas
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int MedicosId { get; set; }
        public int PacientesId { get; set; }
        public Medicos Medicos { get; set; }
        public Pacientes Pacientes { get; set; }
    }
}