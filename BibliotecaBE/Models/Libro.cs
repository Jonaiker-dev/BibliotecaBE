using System;
using System.Collections.Generic;

namespace BibliotecaBE.Models;

public partial class Libro
{
    public string Idlibro { get; set; } = null!;

    public string Titulo { get; set; } = null!;

    public string? Portada { get; set; }

    public string Isbn { get; set; } = null!;

    public int StockVar { get; set; }

    public int Stock { get; set; }

    public string Editorial { get; set; } = null!;

    public DateOnly Publicado { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

    public virtual ICollection<Autor> Idautors { get; set; } = new List<Autor>();
}
