using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalP3.Models
{
    public class Citas
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de de la cita es requerida.")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El Id del medico es requerido")]
        public int MedicosId { get; set; }
        [Required(ErrorMessage = "El Id del Paciente es requerido")]
        public int PacientesId { get; set; }
        public Medicos Medicos { get; set; }
        public Pacientes Pacientes { get; set; }
    }
}