using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

[Table("tbl_editoras")]
public partial class TblEditora
{
    [Key]
    [Column("ID_Editora")]
    public short IdEditora { get; set; }

    [Column("Nome_Editora")]
    [StringLength(50)]
    [Unicode(false)]
    public string? NomeEditora { get; set; }

    [InverseProperty("IdEditoraNavigation")]
    public virtual ICollection<TblLivro> TblLivros { get; set; } = new List<TblLivro>();
}
