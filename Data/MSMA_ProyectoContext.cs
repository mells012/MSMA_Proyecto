using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MSMA_Proyecto.Models;

namespace MSMA_Proyecto.Data
{
    public class MSMA_ProyectoContext : DbContext
    {
        public MSMA_ProyectoContext (DbContextOptions<MSMA_ProyectoContext> options)
            : base(options)
        {
        }

        public DbSet<MSMA_Proyecto.Models.Cervezas> Cervezas { get; set; } = default!;
        public DbSet<MSMA_Proyecto.Models.Comida> Comida { get; set; } = default!;
        public DbSet<MSMA_Proyecto.Models.Cocteles> Cocteles { get; set; } = default!;
    }
}
