using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalP3.Models
{
    public class Medicos
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del medico es requerido.")]
        [MaxLength(100, ErrorMessage = "Escriba un maximo de 100 caracteres.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El exequatur del medico es requerido.")]
        [MaxLength(100, ErrorMessage = "Escriba un maximo de 100 caracteres.")]
        public string Exequatur { get; set; }
        [Required(ErrorMessage = "La especialidad del medico es requerida.")]
        [MaxLength(100, ErrorMessage = "Escriba un maximo de 100 caracteres.")]
        public string Especialidad { get; set; }

    }
}