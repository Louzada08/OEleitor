using Microsoft.EntityFrameworkCore;
using OEleitor.Infra.CrossCurtting.Messages;
using OEleitor.WebApp.MVC.Models;

namespace OEleitor.WebApp.MVC.Data
{
    public class OEleitorWebAppMVCContext : DbContext
    {
        public OEleitorWebAppMVCContext (DbContextOptions<OEleitorWebAppMVCContext> options)
            : base(options)
        {
        }

        public DbSet<BairroViewModel> Bairros { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<EleitorViewModel> Eleitores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Event>();
            modelBuilder.Ignore<FoneEleitor>();
        }
    }
}
