using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalP3.Models
{
    public class Habitaciones
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El numero de habitacion es requerido.")]
        [MaxLength(30, ErrorMessage = "Escriba un maximo de 30 caracteres.")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "El tipo de habitacion es requerido.")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "El precio por dia de la habitacion es requerido.")]
        [MaxLength(30, ErrorMessage = "Escriba un maximo de 30 caracteres.")]
        public double PrecioPorDia { get; set; }
    }
    
    public enum Tipo
    {
        Doble, Privada, Suite
    }
}