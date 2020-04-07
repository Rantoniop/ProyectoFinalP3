using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalP3.Models
{
    public class Pacientes
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La cedula del paciente es requerida.")]
        [MaxLength(30, ErrorMessage = "Escriba un maximo de 30 caracteres.")]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "El nombre del paciente es requerido.")]
        [MaxLength(100, ErrorMessage = "Escriba un maximo de 100 caracteres.")]
        public string Nombre { get; set; }
        public bool Asegurado { get; set; }
    }

}