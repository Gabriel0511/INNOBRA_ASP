using INNOBRA_ASP.DB.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INNOBRA_ASP.DB.Data
{
    public class Context : DbContext
    {
        public DbSet<ItemTipo> ItemTipos { get; set; }
        public DbSet<Unidad> Unidades { get; set; }
        public DbSet<ItemTipoRenglon> ItemTipoRenglones { get; set; }
        public DbSet<Recurso> Recursos { get; set; }
        public DbSet<ItemRenglon> ItemRenglones { get; set; }
        public DbSet<Obra> Obras { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Avance> Avances { get; set; }


        public Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                                          .SelectMany(t => t.GetForeignKeys())
                                          .Where(fk => !fk.IsOwnership
                                          && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }
            
            //ENUM 
            modelBuilder.Entity<Recurso>()
           .Property(r => r.Tipo)
           .HasConversion<int>(); // Mapeo a entero

            base.OnModelCreating(modelBuilder);


        }
    }
}
