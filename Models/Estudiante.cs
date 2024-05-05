using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaIngenieria.Models;

[Table("Estudiante")]
public partial class Estudiante
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(255)]
    public string? Nombre { get; set; }

    [StringLength(255)]
    public string? Correo { get; set; }

    [StringLength(255)]
    public string? Cedula { get; set; }

    [ForeignKey("EstudianteId")]
    [InverseProperty("Estudiantes")]
    public virtual ICollection<Materium> Materia { get; set; } = new List<Materium>();
}
