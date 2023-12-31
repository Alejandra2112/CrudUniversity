﻿// <auto-generated />
using System;
using CrudUniversity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CrudUniversity.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CrudUniversity.Models.Cursos", b =>
                {
                    b.Property<int>("IdCurso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCurso"));

                    b.Property<int>("Creditos")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCurso");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("CrudUniversity.Models.Estudiante", b =>
                {
                    b.Property<int>("IdEstudiante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstudiante"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaInscripcion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEstudiante");

                    b.ToTable("Estudiante");
                });

            modelBuilder.Entity("CrudUniversity.Models.Inscripcion", b =>
                {
                    b.Property<int>("IdInscripcion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInscripcion"));

                    b.Property<int>("IdCurso")
                        .HasColumnType("int");

                    b.Property<int>("IdEstudiante")
                        .HasColumnType("int");

                    b.Property<int?>("cursosIdCurso")
                        .HasColumnType("int");

                    b.Property<int?>("estudianteIdEstudiante")
                        .HasColumnType("int");

                    b.Property<int?>("grado")
                        .HasColumnType("int");

                    b.HasKey("IdInscripcion");

                    b.HasIndex("cursosIdCurso");

                    b.HasIndex("estudianteIdEstudiante");

                    b.ToTable("Inscripcion");
                });

            modelBuilder.Entity("CrudUniversity.Models.Inscripcion", b =>
                {
                    b.HasOne("CrudUniversity.Models.Cursos", "cursos")
                        .WithMany("Inscripciones")
                        .HasForeignKey("cursosIdCurso");

                    b.HasOne("CrudUniversity.Models.Estudiante", "estudiante")
                        .WithMany("Inscripciones")
                        .HasForeignKey("estudianteIdEstudiante");

                    b.Navigation("cursos");

                    b.Navigation("estudiante");
                });

            modelBuilder.Entity("CrudUniversity.Models.Cursos", b =>
                {
                    b.Navigation("Inscripciones");
                });

            modelBuilder.Entity("CrudUniversity.Models.Estudiante", b =>
                {
                    b.Navigation("Inscripciones");
                });
#pragma warning restore 612, 618
        }
    }
}
