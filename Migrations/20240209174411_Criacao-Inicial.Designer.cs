﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoBancodeDdos.Models;

#nullable disable

namespace ProjetoBancodeDados.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20240209174411_Criacao-Inicial")]
    partial class CriacaoInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjetoBancoDeDados.Models.Inscricoes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("InscricoesId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EventosId")
                        .HasColumnType("int");

                    b.Property<int>("PagamentosId")
                        .HasColumnType("int");

                    b.Property<int>("PassagensId")
                        .HasColumnType("int");

                    b.Property<int>("UsuariosId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventosId");

                    b.HasIndex("PagamentosId");

                    b.HasIndex("PassagensId");

                    b.HasIndex("UsuariosId");

                    b.ToTable("Inscricoes");
                });

            modelBuilder.Entity("ProjetoBancoDeDados.Models.Pagamentos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PagamentosId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ValorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ValorId");

                    b.HasKey("Id");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("ProjetoBancoDeDados.Models.Passagens", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PassagensId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DescricaoId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DescricaoId");

                    b.HasKey("Id");

                    b.ToTable("Passagens");
                });

            modelBuilder.Entity("ProjetoBancoDeDados.Models.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UsuarioId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EmailId");

                    b.Property<string>("NomeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomeId");

                    b.Property<string>("SenhaId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SenhaId");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ProjetoBancodeDados.Models.Eventos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EventosId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Criacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DescricaoId");

                    b.Property<string>("DataAtualizacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DataAtualizacaoId");

                    b.Property<string>("DataCriacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DataCriacaoId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomeId");

                    b.HasKey("Id");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("ProjetoBancoDeDados.Models.Inscricoes", b =>
                {
                    b.HasOne("ProjetoBancodeDados.Models.Eventos", "Eventos")
                        .WithMany()
                        .HasForeignKey("EventosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoBancoDeDados.Models.Pagamentos", "PagamentoId")
                        .WithMany()
                        .HasForeignKey("PagamentosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoBancoDeDados.Models.Passagens", "Passagens")
                        .WithMany()
                        .HasForeignKey("PassagensId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoBancoDeDados.Models.Usuarios", "Usuarios")
                        .WithMany()
                        .HasForeignKey("UsuariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Eventos");

                    b.Navigation("PagamentoId");

                    b.Navigation("Passagens");

                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
