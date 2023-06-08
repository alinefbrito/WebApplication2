using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

[Table("tbl_autores")]
public partial class TblAutore
{
    [Key]
    [Column("ID_Autor")]
    public short IdAutor { get; set; }

    [Column("Nome_Autor")]
    [StringLength(50)]
    [Unicode(false)]
    public string? NomeAutor { get; set; }

    [Column("Sobrenome_Autor")]
    [StringLength(60)]
    [Unicode(false)]
    public string? SobrenomeAutor { get; set; }

    [InverseProperty("IdAutorNavigation")]
    public virtual ICollection<TblLivro> TblLivros { get; set; } = new List<TblLivro>();
}
