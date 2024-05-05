using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaIngenieria.Models;

[Table("Semestre")]
public partial class Semestre
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    public int? Anio { get; set; }

    public int? Periodo { get; set; }

    [InverseProperty("Semestre")]
    public virtual ICollection<Calificacion> Calificacions { get; set; } = new List<Calificacion>();
}
