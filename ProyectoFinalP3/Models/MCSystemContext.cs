using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProyectoFinalP3.Models
{
    public class MCSystemContext: DbContext
    {
        public MCSystemContext()
            : base("Cadena1")
        {
            
        }

        public DbSet<Medicos> Medicos { get; set; }
        public DbSet<Pacientes> Pacientes { get; set; }
        public DbSet<Habitaciones> Habitaciones { get; set; }
        public DbSet<Citas> Citas { get; set; }
        public DbSet<Ingresos> Ingresos { get; set; }
        public DbSet<Altas> Altas { get; set; }
    }
}