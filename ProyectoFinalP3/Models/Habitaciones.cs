using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinalP3.Models
{
    public class Habitaciones
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public double PrecioPorDia { get; set; }
    }
    
    public enum Tipo
    {
        Doble, Privada, Suite
    }
}