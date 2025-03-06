using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaBE.Models;

public partial class VistaDetalle
{
    [Key]
    public int Idprestamo { get; set; }

    public string Titulo { get; set; } = null!;

    public string Autor { get; set; } = null!;

    public string Isbn { get; set; } = null!;

    public int StockVar { get; set; }

    public int Stock { get; set; }

    public string Usuario { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public DateOnly FechaDevolucion { get; set; }

    public string Idlibro { get; set; } = null!;

    public string Estado { get; set; } = null!;
}
