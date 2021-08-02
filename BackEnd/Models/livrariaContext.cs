using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BackEnd.Models
{
    public partial class livrariaContext : DbContext
    {
        public livrariaContext()
        {
        }

        public livrariaContext(DbContextOptions<livrariaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCliente> TbCliente { get; set; }
        public virtual DbSet<TbFuncionario> TbFuncionario { get; set; }
        public virtual DbSet<TbLivro> TbLivro { get; set; }
        public virtual DbSet<TbLivroCliente> TbLivroCliente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("host=localhost;user=root;password=12345;database=livraria", x => x.ServerVersion("8.0.26-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbCliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PRIMARY");

                entity.ToTable("tb_cliente");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Nascimento)
                    .HasColumnName("nascimento")
                    .HasColumnType("date");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Telefone)
                    .HasColumnName("telefone")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<TbFuncionario>(entity =>
            {
                entity.HasKey(e => e.IdFuncionario)
                    .HasName("PRIMARY");

                entity.ToTable("tb_funcionario");

                entity.Property(e => e.IdFuncionario).HasColumnName("id_funcionario");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Endereco)
                    .HasColumnName("endereco")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Nascimento)
                    .HasColumnName("nascimento")
                    .HasColumnType("date");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Salario)
                    .HasColumnName("salario")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.Telefone)
                    .HasColumnName("telefone")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<TbLivro>(entity =>
            {
                entity.HasKey(e => e.IdLivro)
                    .HasName("PRIMARY");

                entity.ToTable("tb_livro");

                entity.Property(e => e.IdLivro).HasColumnName("id_livro");

                entity.Property(e => e.Autor)
                    .HasColumnName("autor")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Disponivel).HasColumnName("disponivel");

                entity.Property(e => e.Linguagem)
                    .HasColumnName("linguagem")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Preco)
                    .HasColumnName("preco")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.Publicado)
                    .HasColumnName("publicado")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<TbLivroCliente>(entity =>
            {
                entity.HasKey(e => e.IdLivroCliente)
                    .HasName("PRIMARY");

                entity.ToTable("tb_livro_cliente");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("id_cliente");

                entity.HasIndex(e => e.IdLivro)
                    .HasName("id_livro");

                entity.Property(e => e.IdLivroCliente).HasColumnName("id_livro_cliente");

                entity.Property(e => e.DataCompra)
                    .HasColumnName("data_compra")
                    .HasColumnType("date");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdLivro).HasColumnName("id_livro");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TbLivroCliente)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("tb_livro_cliente_ibfk_2");

                entity.HasOne(d => d.IdLivroNavigation)
                    .WithMany(p => p.TbLivroCliente)
                    .HasForeignKey(d => d.IdLivro)
                    .HasConstraintName("tb_livro_cliente_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
