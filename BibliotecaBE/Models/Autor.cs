using System;
using System.Collections.Generic;

namespace BibliotecaBE.Models;

public partial class Autor
{
    public string Idautor { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Nacionalidad { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public virtual Nacionalidad NacionalidadNavigation { get; set; } = null!;

    public virtual ICollection<Libro> Idlibros { get; set; } = new List<Libro>();
}
