using System;
using System.Collections.Generic;

namespace BibliotecaBE.Models;

public partial class DetalleLibro
{
    public string Idlibro { get; set; } = null!;

    public string Titulo { get; set; } = null!;

    public string Autor { get; set; } = null!;

    public string? Nacionalidad { get; set; }

    public string Isbn { get; set; } = null!;

    public int Stock { get; set; }
}
