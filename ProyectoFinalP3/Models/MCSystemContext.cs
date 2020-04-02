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
            : base("MCSystemDB")
        {
            
        }

        public DbSet<Medicos> Medicos { get; set; }
 
    }
}