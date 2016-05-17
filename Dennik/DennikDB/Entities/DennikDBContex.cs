using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DennikDB.Entities {
    public class DennikDBContex : DbContext {
        public DennikDBContex()
            : base("name=Dennik") {

            Database.SetInitializer<DennikDBContex>(new CreateDatabaseIfNotExists<DennikDBContex>());
        }
        public DbSet<Evento> Eventos { get; set; } 
        public DbSet<Articulo> Inventario { get; set; }
        public DbSet<Provedor> Provedores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Evento>().ToTable("Eventos");
        }
    }
}
