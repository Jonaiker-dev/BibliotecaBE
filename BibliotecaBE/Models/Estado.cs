using System;
using System.Collections.Generic;

namespace BibliotecaBE.Models;

public partial class Estado
{
    public int Idestado { get; set; }

    public string Estado1 { get; set; } = null!;

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
