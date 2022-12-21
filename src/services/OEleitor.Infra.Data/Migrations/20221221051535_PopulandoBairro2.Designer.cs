﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OEleitor.Infra.Data.Context;

#nullable disable

namespace OEleitor.Infra.Data.Migrations
{
    [DbContext(typeof(OEleitorDbContext))]
    [Migration("20221221051535_PopulandoBairro2")]
    partial class PopulandoBairro2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OEleitor.Domain.Entities.Bairro", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("BairroNome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Bairros");
                });

            modelBuilder.Entity("OEleitor.Domain.Entities.Dependente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("EleitorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Fone")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("Nascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Tipo")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EleitorId");

                    b.ToTable("Dependentes");
                });

            modelBuilder.Entity("OEleitor.Domain.Entities.Eleitor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("Aniversario")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Apelido")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Sexo")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Eleitores");
                });

            modelBuilder.Entity("OEleitor.Domain.Entities.Endereco", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("BairroId")
                        .HasColumnType("bigint");

                    b.Property<string>("Cep")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Complemento")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("EleitorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Numero")
                        .HasMaxLength(5)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("BairroId")
                        .IsUnique();

                    b.HasIndex("EleitorId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("OEleitor.Domain.Entities.Dependente", b =>
                {
                    b.HasOne("OEleitor.Domain.Entities.Eleitor", "Eleitor")
                        .WithMany("Dependentes")
                        .HasForeignKey("EleitorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Eleitor");
                });

            modelBuilder.Entity("OEleitor.Domain.Entities.Eleitor", b =>
                {
                    b.OwnsOne("OEleitor.Domain.Entities.Eleitor+FoneEleitor", "Fone", b1 =>
                        {
                            b1.Property<long>("EleitorId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Fone1")
                                .HasColumnType("varchar(15)")
                                .HasColumnName("Fone1");

                            b1.Property<bool?>("Fone1TemWhatsapp")
                                .HasColumnType("boolean")
                                .HasColumnName("Fone1TemWhatsapp");

                            b1.Property<string>("Fone2")
                                .HasColumnType("varchar(15)")
                                .HasColumnName("Fone2");

                            b1.Property<bool?>("Fone2TemWhatsapp")
                                .HasColumnType("boolean")
                                .HasColumnName("Fone2TemWhatsapp");

                            b1.HasKey("EleitorId");

                            b1.ToTable("Eleitores");

                            b1.WithOwner()
                                .HasForeignKey("EleitorId");
                        });

                    b.Navigation("Fone");
                });

            modelBuilder.Entity("OEleitor.Domain.Entities.Endereco", b =>
                {
                    b.HasOne("OEleitor.Domain.Entities.Bairro", "Bairro")
                        .WithOne("Endereco")
                        .HasForeignKey("OEleitor.Domain.Entities.Endereco", "BairroId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("OEleitor.Domain.Entities.Eleitor", "Eleitor")
                        .WithOne("Endereco")
                        .HasForeignKey("OEleitor.Domain.Entities.Endereco", "EleitorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Bairro");

                    b.Navigation("Eleitor");
                });

            modelBuilder.Entity("OEleitor.Domain.Entities.Bairro", b =>
                {
                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("OEleitor.Domain.Entities.Eleitor", b =>
                {
                    b.Navigation("Dependentes");

                    b.Navigation("Endereco");
                });
#pragma warning restore 612, 618
        }
    }
}
