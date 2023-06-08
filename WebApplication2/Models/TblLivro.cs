using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

[Table("tbl_livros")]
[Index("Isbn", Name = "UQ__tbl_livr__447D36EA3E234585", IsUnique = true)]
public partial class TblLivro
{
    [Key]
    [Column("ID_Livro")]
    public short IdLivro { get; set; }

    [Column("Nome_Livro")]
    [StringLength(50)]
    [Unicode(false)]
    public string NomeLivro { get; set; } = null!;

    [Column("ISBN")]
    [StringLength(30)]
    [Unicode(false)]
    public string Isbn { get; set; } = null!;

    [Column("ID_Autor")]
    public short IdAutor { get; set; }

    [Column("Data_Pub", TypeName = "date")]
    public DateTime DataPub { get; set; }

    [Column("Preco_Livro", TypeName = "money")]
    public decimal PrecoLivro { get; set; }

    [Column("ID_Editora")]
    public short IdEditora { get; set; }

    [ForeignKey("IdAutor")]
    [InverseProperty("TblLivros")]
    public virtual TblAutore IdAutorNavigation { get; set; } = null!;

    [ForeignKey("IdEditora")]
    [InverseProperty("TblLivros")]
    public virtual TblEditora IdEditoraNavigation { get; set; } = null!;
}
