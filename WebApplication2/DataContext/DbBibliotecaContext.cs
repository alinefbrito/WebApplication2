using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.DataContext;

public partial class DbBibliotecaContext : DbContext
{
    public DbBibliotecaContext()
    {
    }

    public DbBibliotecaContext(DbContextOptions<DbBibliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAutore> TblAutores { get; set; }

    public virtual DbSet<TblEditora> TblEditoras { get; set; }

    public virtual DbSet<TblLivro> TblLivros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=db_Biblioteca;Encrypt =False;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAutore>(entity =>
        {
            entity.HasKey(e => e.IdAutor).HasName("PK__tbl_auto__9626AD263D17648A");
        });

        modelBuilder.Entity<TblEditora>(entity =>
        {
            entity.HasKey(e => e.IdEditora).HasName("PK__tbl_edit__478AEA9FA661106D");
        });

        modelBuilder.Entity<TblLivro>(entity =>
        {
            entity.HasKey(e => e.IdLivro).HasName("pk_id_livro");

            entity.HasOne(d => d.IdAutorNavigation).WithMany(p => p.TblLivros).HasConstraintName("fk_ID_Autor");

            entity.HasOne(d => d.IdEditoraNavigation).WithMany(p => p.TblLivros).HasConstraintName("fk_ID_Editora");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
