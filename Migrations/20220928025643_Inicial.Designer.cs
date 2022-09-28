﻿// <auto-generated />
using System;
using MangaI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MangaI.Migrations
{
    [DbContext(typeof(ContextoBD))]
    [Migration("20220928025643_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DisciplinaMatriz", b =>
                {
                    b.Property<int>("DisciplinasId")
                        .HasColumnType("int");

                    b.Property<int>("MatrizesId")
                        .HasColumnType("int");

                    b.HasKey("DisciplinasId", "MatrizesId");

                    b.HasIndex("MatrizesId");

                    b.ToTable("DisciplinaMatriz");
                });

            modelBuilder.Entity("MangaI.Models.Avaliacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.Property<int>("TurmaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("Decimal(13,2)");

                    b.HasKey("Id");

                    b.HasIndex("TurmaId");

                    b.ToTable("Avaliacoes");
                });

            modelBuilder.Entity("MangaI.Models.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NomeCurso")
                        .IsRequired()
                        .HasColumnType("varchar(35)");

                    b.HasKey("Id");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("MangaI.Models.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.HasKey("Id");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("MangaI.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("MangaI.Models.Frequencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Dia")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MatriculaId")
                        .HasColumnType("int");

                    b.Property<bool>("Presente")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("MatriculaId");

                    b.ToTable("Frequencias");
                });

            modelBuilder.Entity("MangaI.Models.Matricula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("NotaFinal")
                        .HasColumnType("Decimal(13,2)");

                    b.Property<int>("TurmaId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TurmaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Matriculas");
                });

            modelBuilder.Entity("MangaI.Models.Matriz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<int>("Versao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.ToTable("Matrizes");
                });

            modelBuilder.Entity("MangaI.Models.NotaAluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AvaliacaoId")
                        .HasColumnType("int");

                    b.Property<int>("MatriculaId")
                        .HasColumnType("int");

                    b.Property<decimal>("NotaObtida")
                        .HasColumnType("decimal(13,2)");

                    b.HasKey("Id");

                    b.HasIndex("AvaliacaoId");

                    b.HasIndex("MatriculaId");

                    b.ToTable("NotaAlunos");
                });

            modelBuilder.Entity("MangaI.Models.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.HasKey("Id");

                    b.ToTable("Perfis");
                });

            modelBuilder.Entity("MangaI.Models.Telefone", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Telefones");
                });

            modelBuilder.Entity("MangaI.Models.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("MangaI.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.Property<int>("PerfilId")
                        .HasColumnType("int");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("PerfilId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("DisciplinaMatriz", b =>
                {
                    b.HasOne("MangaI.Models.Disciplina", null)
                        .WithMany()
                        .HasForeignKey("DisciplinasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MangaI.Models.Matriz", null)
                        .WithMany()
                        .HasForeignKey("MatrizesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MangaI.Models.Avaliacao", b =>
                {
                    b.HasOne("MangaI.Models.Turma", "Turma")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("MangaI.Models.Frequencia", b =>
                {
                    b.HasOne("MangaI.Models.Matricula", "Matricula")
                        .WithMany("Frequencias")
                        .HasForeignKey("MatriculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Matricula");
                });

            modelBuilder.Entity("MangaI.Models.Matricula", b =>
                {
                    b.HasOne("MangaI.Models.Turma", "Turma")
                        .WithMany("Matriculas")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MangaI.Models.Usuario", "Usuario")
                        .WithMany("Matriculas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Turma");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MangaI.Models.Matriz", b =>
                {
                    b.HasOne("MangaI.Models.Curso", "Curso")
                        .WithMany("Matrizes")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("MangaI.Models.NotaAluno", b =>
                {
                    b.HasOne("MangaI.Models.Avaliacao", "Avaliacao")
                        .WithMany("NotaAlunos")
                        .HasForeignKey("AvaliacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MangaI.Models.Matricula", "Matricula")
                        .WithMany("NotasAlunos")
                        .HasForeignKey("MatriculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Avaliacao");

                    b.Navigation("Matricula");
                });

            modelBuilder.Entity("MangaI.Models.Telefone", b =>
                {
                    b.HasOne("MangaI.Models.Usuario", "Usuario")
                        .WithMany("Telefones")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MangaI.Models.Turma", b =>
                {
                    b.HasOne("MangaI.Models.Disciplina", "Disciplina")
                        .WithMany("Turmas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disciplina");
                });

            modelBuilder.Entity("MangaI.Models.Usuario", b =>
                {
                    b.HasOne("MangaI.Models.Endereco", "Endereco")
                        .WithMany("Usuarios")
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MangaI.Models.Perfil", "Perfil")
                        .WithMany("Usuarios")
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("MangaI.Models.Avaliacao", b =>
                {
                    b.Navigation("NotaAlunos");
                });

            modelBuilder.Entity("MangaI.Models.Curso", b =>
                {
                    b.Navigation("Matrizes");
                });

            modelBuilder.Entity("MangaI.Models.Disciplina", b =>
                {
                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("MangaI.Models.Endereco", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("MangaI.Models.Matricula", b =>
                {
                    b.Navigation("Frequencias");

                    b.Navigation("NotasAlunos");
                });

            modelBuilder.Entity("MangaI.Models.Perfil", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("MangaI.Models.Turma", b =>
                {
                    b.Navigation("Avaliacoes");

                    b.Navigation("Matriculas");
                });

            modelBuilder.Entity("MangaI.Models.Usuario", b =>
                {
                    b.Navigation("Matriculas");

                    b.Navigation("Telefones");
                });
#pragma warning restore 612, 618
        }
    }
}
