using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaIngenieria.Models;

public partial class Materium
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(255)]
    public string? Nombre { get; set; }

    [Column("ProfesorID")]
    public int? ProfesorId { get; set; }

    [ForeignKey("ProfesorId")]
    [InverseProperty("Materia")]
    public virtual Profesor? Profesor { get; set; }

    [ForeignKey("MateriaId")]
    [InverseProperty("Materia")]
    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
}
