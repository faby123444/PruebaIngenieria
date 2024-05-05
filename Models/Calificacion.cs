using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaIngenieria.Models;

[Table("Calificacion")]
public partial class Calificacion
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("Nota_1")]
    public double? Nota1 { get; set; }

    [Column("Nota_2")]
    public double? Nota2 { get; set; }

    [Column("Nota_3")]
    public double? Nota3 { get; set; }

    public double? NotaFinal { get; set; }

    [Column("SemestreID")]
    public int? SemestreId { get; set; }

    [ForeignKey("SemestreId")]
    [InverseProperty("Calificacions")]
    public virtual Semestre? Semestre { get; set; }
}
