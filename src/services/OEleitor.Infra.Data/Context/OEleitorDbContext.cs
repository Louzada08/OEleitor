﻿using Microsoft.EntityFrameworkCore;
using OEleitor.Domain.Entities;
using OEleitor.Infra.Data.EntitiesConfiguration;
using System.Linq;

namespace OEleitor.Infra.Data.Context
{
    public class OEleitorDbContext : DbContext
    {
        public OEleitorDbContext(DbContextOptions<OEleitorDbContext> options) : base(options)
        {
        }

        public DbSet<Eleitor> Eleitores { get; set; }
        public DbSet<Dependente> Dependentes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Bairro> Bairros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                    e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                    property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfiguration(new EleitorConfiguration());
            modelBuilder.ApplyConfiguration(new DependenteConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            modelBuilder.ApplyConfiguration(new BairroConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
