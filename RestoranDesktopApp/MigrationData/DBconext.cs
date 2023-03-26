using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using RestoranDesktopApp.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDesktopApp.MigrationData
{
    public class DBcontext : DbContext

    {
        public DbSet<Buyurtmalar> Buyurtmalar { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Taomlar> Taomlar { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("postgres://kikitjqj:mqCl4CqXPeZdaiHaOujDr8ITXT1vSK_9@mahmud.db.elephantsql.com/kikitjqj");
        }

    }
}
