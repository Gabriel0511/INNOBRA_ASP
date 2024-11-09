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
            modelBuilder.Entity<Presupuesto>()
                .HasOne(p => p.Obra)
                .WithMany(o => o.Presupuestos) // Ahora 'Obra' tiene la colección 'Presupuestos'
                .HasForeignKey(p => p.Obra_Id) // Usa 'Obra_Id' como la clave foránea
                .OnDelete(DeleteBehavior.Restrict); // O el comportamiento de eliminación que prefieras

            modelBuilder.Entity<Recurso>()
                .HasOne(p => p.Unidad)
                .WithMany(o => o.Recursos) 
                .HasForeignKey(p => p.Unidad_Id)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<ItemTipo>()
                .HasOne(p => p.Unidad)
                .WithMany(o => o.ItemTipos) 
                .HasForeignKey(p => p.Unidad_Id) 
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<ItemTipoRenglon>()
                .HasOne(p => p.Recurso)
                .WithMany(o => o.ItemTipoRenglons) 
                .HasForeignKey(p => p.Recurso_Id) 
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<ItemTipoRenglon>()
                .HasOne(p => p.ItemTipo)
                .WithMany(o => o.ItemTipoRenglons) 
                .HasForeignKey(p => p.Item_Tipos_Id) 
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<ItemTipoRenglon>()
                .HasOne(p => p.Recurso)
                .WithMany(o => o.ItemTipoRenglons) 
                .HasForeignKey(p => p.Recurso_Id) 
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<ItemTipo>()
                .HasOne(p => p.Unidad)
                .WithMany(o => o.ItemTipos) 
                .HasForeignKey(p => p.Unidad_Id) 
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemRenglon>()
                .HasOne(p => p.Item)
                .WithMany(o => o.ItemRenglons) 
                .HasForeignKey(p => p.Item_Id) 
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<ItemRenglon>()
                .HasOne(p => p.Recurso)
                .WithMany(o => o.ItemRenglons) 
                .HasForeignKey(p => p.Recursos_Id) 
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Item>()
                .HasOne(p => p.ItemTipo)
                .WithMany(o => o.Items) 
                .HasForeignKey(p => p.Item_Tipos_Id) 
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Item>()
                .HasOne(p => p.Presupuesto)
                .WithMany(o => o.Items) 
                .HasForeignKey(p => p.Presupuesto_Id) 
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Avance>()
                .HasOne(p => p.Recurso)
                .WithMany(o => o.Avances) 
                .HasForeignKey(p => p.Recurso_Id) 
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Avance>()
                .HasOne(p => p.Item)
                .WithMany(o => o.Avances)
                .HasForeignKey(p => p.Item_Id) 
                .OnDelete(DeleteBehavior.Restrict);


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
