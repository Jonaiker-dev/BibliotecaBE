using System;
using System.Collections.Generic;

namespace BibliotecaBE.Models;

public partial class Prestamo
{
    public int Idprestamo { get; set; }

    public int Idusuario { get; set; }

    public string Idlibro { get; set; } = null!;

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaDevolucion { get; set; }

    public int Estado { get; set; }

    public virtual Estado EstadoNavigation { get; set; } = null!;

    public virtual Libro IdlibroNavigation { get; set; } = null!;

    public virtual Usuario IdusuarioNavigation { get; set; } = null!;
}
