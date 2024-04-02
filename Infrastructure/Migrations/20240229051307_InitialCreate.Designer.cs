﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(EdusisDBContext))]
    [Migration("20240229051307_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Cursos.Curso", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("curso_id");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("descripcion");

                    b.Property<string>("NivelEducativo")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasColumnName("nivel_educativo");

                    b.HasKey("Id")
                        .HasName("PK_CURSOS");

                    b.ToTable("cursos", (string)null);
                });

            modelBuilder.Entity("Domain.Cursos.Divisiones.Division", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("division_id");

                    b.Property<Guid>("CursoID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("curso_id")
                        .HasColumnOrder(0);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("descripicion");

                    b.Property<Guid?>("Preceptor")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("preceptor_id");

                    b.HasKey("Id")
                        .HasName("PK_DIVISIONES");

                    b.HasIndex("CursoID");

                    b.HasIndex("Preceptor")
                        .IsUnique()
                        .HasFilter("[preceptor_id] IS NOT NULL");

                    b.ToTable("divisiones", (string)null);
                });

            modelBuilder.Entity("Domain.Cursos.Materias.Materia", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("materia_id");

                    b.Property<Guid>("CursoID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("curso_id")
                        .HasColumnOrder(0);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("descripcion");

                    b.Property<byte>("HorasCatedra")
                        .HasColumnType("tinyint")
                        .HasColumnName("horas_catedra");

                    b.HasKey("Id")
                        .HasName("PK_MATERIAS");

                    b.HasIndex("CursoID");

                    b.ToTable("materias", (string)null);
                });

            modelBuilder.Entity("Domain.Personas.Persona", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("persona_id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("telefono");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("personas", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Domain.Alumnos.Alumno", b =>
                {
                    b.HasBaseType("Domain.Personas.Persona");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("date")
                        .HasColumnName("fecha_alta");

                    b.Property<DateTime?>("FechaBaja")
                        .HasColumnType("date")
                        .HasColumnName("fecha_baja");

                    b.Property<string>("Legajo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("legajo");

                    b.ToTable("alumnos", (string)null);
                });

            modelBuilder.Entity("Domain.Docentes.Docente", b =>
                {
                    b.HasBaseType("Domain.Personas.Persona");

                    b.Property<string>("CUIL")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(11)")
                        .HasColumnName("cuil");

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit")
                        .HasColumnName("esta_activo");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("date")
                        .HasColumnName("fecha_alta");

                    b.Property<DateTime?>("FechaBaja")
                        .HasColumnType("date")
                        .HasColumnName("fecha_baja");

                    b.Property<string>("Legajo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(6)")
                        .HasColumnName("legajo");

                    b.ToTable("docentes", (string)null);
                });

            modelBuilder.Entity("Domain.Cursos.Divisiones.Division", b =>
                {
                    b.HasOne("Domain.Cursos.Curso", null)
                        .WithMany("Divisiones")
                        .HasForeignKey("CursoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_CURSOS_DIVISIONES");

                    b.HasOne("Domain.Docentes.Docente", null)
                        .WithOne()
                        .HasForeignKey("Domain.Cursos.Divisiones.Division", "Preceptor")
                        .HasConstraintName("FK_DOCENTES_DIVISIONES");

                    b.OwnsMany("Domain.Cursos.Divisiones.Cursantes.Cursante", "ListadosDefinitivos", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("cursante_id");

                            b1.Property<Guid>("AlumnoID")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("alumno_id");

                            b1.Property<Guid>("DivisionID")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("division_id")
                                .HasColumnOrder(0);

                            b1.HasKey("Id")
                                .HasName("PK_CURSANTES");

                            b1.HasIndex("AlumnoID");

                            b1.HasIndex("DivisionID");

                            b1.ToTable("cursantes", (string)null);

                            b1.HasOne("Domain.Alumnos.Alumno", null)
                                .WithMany()
                                .HasForeignKey("AlumnoID")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired()
                                .HasConstraintName("FK_ALUMNOS_CURSANTES");

                            b1.WithOwner()
                                .HasForeignKey("DivisionID")
                                .HasConstraintName("FK_DIVISIONES_CURSANTES");

                            b1.OwnsOne("Domain.Cursos.Divisiones.Cursantes.CicloLectivo", "CicloLectivo", b2 =>
                                {
                                    b2.Property<Guid>("CursanteId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Periodo")
                                        .IsRequired()
                                        .HasMaxLength(4)
                                        .HasColumnType("nvarchar(4)")
                                        .HasColumnName("periodo");

                                    b2.HasKey("CursanteId");

                                    b2.ToTable("cursantes");

                                    b2.WithOwner()
                                        .HasForeignKey("CursanteId");
                                });

                            b1.OwnsMany("Domain.Cursos.Divisiones.Cursantes.Calificacion", "Calificaciones", b2 =>
                                {
                                    b2.Property<int>("calificacion_id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int");

                                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b2.Property<int>("calificacion_id"));

                                    b2.Property<DateTime?>("Fecha")
                                        .HasColumnType("date")
                                        .HasColumnName("fecha");

                                    b2.Property<string>("Instancia")
                                        .IsRequired()
                                        .HasColumnType("varchar(15)")
                                        .HasColumnName("instancia");

                                    b2.Property<Guid>("MateriaID")
                                        .HasColumnType("uniqueidentifier")
                                        .HasColumnName("materia_id");

                                    b2.Property<decimal?>("Nota")
                                        .HasColumnType("decimal(5,2)")
                                        .HasColumnName("nota");

                                    b2.Property<bool>("_asistencia")
                                        .HasColumnType("bit")
                                        .HasColumnName("asistencia");

                                    b2.Property<Guid>("cursante_id")
                                        .HasColumnType("uniqueidentifier");

                                    b2.HasKey("calificacion_id");

                                    b2.HasIndex("MateriaID");

                                    b2.HasIndex("cursante_id");

                                    b2.ToTable("calificaciones", (string)null);

                                    b2.HasOne("Domain.Cursos.Materias.Materia", null)
                                        .WithMany()
                                        .HasForeignKey("MateriaID")
                                        .OnDelete(DeleteBehavior.NoAction)
                                        .IsRequired()
                                        .HasConstraintName("FK_MATERIAS_CALIFICACIONES");

                                    b2.WithOwner()
                                        .HasForeignKey("cursante_id")
                                        .HasConstraintName("FK_CURSANTES_CALIFICACIONES");
                                });

                            b1.Navigation("Calificaciones");

                            b1.Navigation("CicloLectivo")
                                .IsRequired();
                        });

                    b.Navigation("ListadosDefinitivos");
                });

            modelBuilder.Entity("Domain.Cursos.Materias.Materia", b =>
                {
                    b.HasOne("Domain.Cursos.Curso", null)
                        .WithMany("Materias")
                        .HasForeignKey("CursoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_CURSOS_MATERIAS");

                    b.OwnsMany("Domain.Cursos.Materias.Horario", "Horarios", b1 =>
                        {
                            b1.Property<Guid>("materia_id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("horario_id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("horario_id"));

                            b1.Property<string>("DiaSemana")
                                .IsRequired()
                                .HasColumnType("varchar(10)")
                                .HasColumnName("dia");

                            b1.Property<TimeSpan>("HoraFin")
                                .HasColumnType("time(0)")
                                .HasColumnName("hora_fin");

                            b1.Property<TimeSpan>("HoraInicio")
                                .HasColumnType("time(0)")
                                .HasColumnName("hora_inicio");

                            b1.Property<string>("Turno")
                                .IsRequired()
                                .HasColumnType("varchar(10)")
                                .HasColumnName("turno");

                            b1.HasKey("materia_id", "horario_id")
                                .HasName("PK_HORARIOS");

                            b1.ToTable("horarios", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("materia_id")
                                .HasConstraintName("FK_MATERIAS_HORARIOS");
                        });

                    b.OwnsMany("Domain.Cursos.Materias.SituacionRevista", "Profesores", b1 =>
                        {
                            b1.Property<Guid>("materia_id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("situacion_revista_id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("situacion_revista_id"));

                            b1.Property<string>("Cargo")
                                .IsRequired()
                                .HasColumnType("varchar(10)")
                                .HasColumnName("cargo");

                            b1.Property<bool>("EnFunciones")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bit")
                                .HasDefaultValue(false)
                                .HasColumnName("en_funciones");

                            b1.Property<DateTime>("FechaAlta")
                                .HasColumnType("date")
                                .HasColumnName("fecha_alta");

                            b1.Property<DateTime?>("FechaBaja")
                                .HasColumnType("date")
                                .HasColumnName("fecha_baja");

                            b1.Property<Guid>("ProfesorId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("profesor_id");

                            b1.HasKey("materia_id", "situacion_revista_id")
                                .HasName("PK_SITUACION-REVISTA");

                            b1.HasIndex("ProfesorId");

                            b1.ToTable("situacion_revista", (string)null);

                            b1.HasOne("Domain.Docentes.Docente", null)
                                .WithMany()
                                .HasForeignKey("ProfesorId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired()
                                .HasConstraintName("FK_DOCENTES_SITUACION-REVISTA");

                            b1.WithOwner()
                                .HasForeignKey("materia_id")
                                .HasConstraintName("FK_MATERIAS_SITUACION-REVISTA");
                        });

                    b.Navigation("Horarios");

                    b.Navigation("Profesores");
                });

            modelBuilder.Entity("Domain.Personas.Persona", b =>
                {
                    b.OwnsOne("Domain.Personas.InformacionPersonal", "InformacionPersonal", b1 =>
                        {
                            b1.Property<Guid>("PersonaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Apellido")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("varchar(50)")
                                .HasColumnName("apellido");

                            b1.Property<int>("Documento")
                                .HasMaxLength(50)
                                .HasColumnType("int")
                                .HasColumnName("documento");

                            b1.Property<DateTime>("FechaNacimiento")
                                .HasColumnType("date")
                                .HasColumnName("fecha_nacimiento");

                            b1.Property<string>("Nacionalidad")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("varchar(20)")
                                .HasColumnName("nacionalidad");

                            b1.Property<string>("Nombre")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("varchar(50)")
                                .HasColumnName("nombre");

                            b1.Property<string>("Sexo")
                                .IsRequired()
                                .HasColumnType("varchar(15)")
                                .HasColumnName("sexo");

                            b1.HasKey("PersonaId");

                            b1.HasIndex("Documento")
                                .IsUnique();

                            b1.ToTable("personas");

                            b1.WithOwner()
                                .HasForeignKey("PersonaId");
                        });

                    b.OwnsOne("Domain.Personas.Domicilios.Domicilio", "Domicilio", b1 =>
                        {
                            b1.Property<Guid>("persona_id")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("persona_id")
                                .HasName("PK_DOMICILIOS");

                            b1.ToTable("domicilios", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("persona_id")
                                .HasConstraintName("FK_PERSONAS_DOMICILIOS");

                            b1.OwnsOne("Domain.Personas.Domicilios.Direccion", "Direccion", b2 =>
                                {
                                    b2.Property<Guid>("Domiciliopersona_id")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Altura")
                                        .HasMaxLength(50)
                                        .HasColumnType("varchar(6)")
                                        .HasColumnName("altura");

                                    b2.Property<string>("Calle")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("varchar(50)")
                                        .HasColumnName("calle");

                                    b2.Property<string>("Observacion")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("varchar(120)")
                                        .HasColumnName("observaciones");

                                    b2.Property<string>("Vivienda")
                                        .IsRequired()
                                        .HasColumnType("varchar(20)")
                                        .HasColumnName("vivienda");

                                    b2.HasKey("Domiciliopersona_id");

                                    b2.ToTable("domicilios");

                                    b2.WithOwner()
                                        .HasForeignKey("Domiciliopersona_id");
                                });

                            b1.OwnsOne("Domain.Personas.Domicilios.Ubicacion", "Ubicacion", b2 =>
                                {
                                    b2.Property<Guid>("Domiciliopersona_id")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Localidad")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("varchar(50)")
                                        .HasColumnName("localidad");

                                    b2.Property<string>("Pais")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("varchar(50)")
                                        .HasColumnName("pais");

                                    b2.Property<string>("Provincia")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("varchar(50)")
                                        .HasColumnName("provincia");

                                    b2.HasKey("Domiciliopersona_id");

                                    b2.ToTable("domicilios");

                                    b2.WithOwner()
                                        .HasForeignKey("Domiciliopersona_id");
                                });

                            b1.Navigation("Direccion")
                                .IsRequired();

                            b1.Navigation("Ubicacion")
                                .IsRequired();
                        });

                    b.Navigation("Domicilio")
                        .IsRequired();

                    b.Navigation("InformacionPersonal")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Alumnos.Alumno", b =>
                {
                    b.HasOne("Domain.Personas.Persona", null)
                        .WithOne()
                        .HasForeignKey("Domain.Alumnos.Alumno", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Docentes.Docente", b =>
                {
                    b.HasOne("Domain.Personas.Persona", null)
                        .WithOne()
                        .HasForeignKey("Domain.Docentes.Docente", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("Domain.Docentes.Licencias.Licencia", "Licencias", b1 =>
                        {
                            b1.Property<int>("licencia_id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("licencia_id"));

                            b1.Property<Guid>("docente_id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Articulo")
                                .IsRequired()
                                .HasColumnType("varchar(15)")
                                .HasColumnName("articulo");

                            b1.Property<int>("Dias")
                                .HasColumnType("int")
                                .HasColumnName("dias");

                            b1.Property<string>("Estado")
                                .IsRequired()
                                .HasColumnType("varchar(15)")
                                .HasColumnName("estado");

                            b1.Property<DateTime>("FechaInicio")
                                .HasColumnType("date")
                                .HasColumnName("fecha_inicio");

                            b1.Property<string>("Observacion")
                                .IsRequired()
                                .HasMaxLength(120)
                                .HasColumnType("varchar(10)")
                                .HasColumnName("observacion");

                            b1.HasKey("licencia_id", "docente_id")
                                .HasName("PK_LICENCIAS");

                            b1.HasIndex("docente_id");

                            b1.ToTable("licencias", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("docente_id")
                                .HasConstraintName("FK_DOCENTES_LICENCIAS");
                        });

                    b.OwnsMany("Domain.Docentes.Puesto", "Puestos", b1 =>
                        {
                            b1.Property<int>("puesto_id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("puesto_id"));

                            b1.Property<Guid>("docente_id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime?>("FechaFin")
                                .HasColumnType("date")
                                .HasColumnName("fecha_fin");

                            b1.Property<DateTime>("FechaInicio")
                                .HasColumnType("date")
                                .HasColumnName("fecha_inicio");

                            b1.Property<string>("Posicion")
                                .IsRequired()
                                .HasColumnType("varchar(15)")
                                .HasColumnName("posicion");

                            b1.HasKey("puesto_id", "docente_id")
                                .HasName("PK_PUESTOS");

                            b1.HasIndex("docente_id");

                            b1.ToTable("puestos", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("docente_id")
                                .HasConstraintName("FK_DOCENTES_PUESTOS");
                        });

                    b.Navigation("Licencias");

                    b.Navigation("Puestos");
                });

            modelBuilder.Entity("Domain.Cursos.Curso", b =>
                {
                    b.Navigation("Divisiones");

                    b.Navigation("Materias");
                });
#pragma warning restore 612, 618
        }
    }
}
