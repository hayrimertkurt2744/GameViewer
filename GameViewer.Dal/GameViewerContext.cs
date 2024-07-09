using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameViewer.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameViewer.Dal
{
    public class GameViewerContext:DbContext
    {
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ProviderParam> ProviderParams { get; set; }
        public DbSet<ParamValue> ParamValues  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=GameViewerDB;UID=sa;PWD=123;TrustServerCertificate=True;");
            }
        }
    }
}
