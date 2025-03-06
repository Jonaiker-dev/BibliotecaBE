using System;
using System.Collections.Generic;

namespace BibliotecaBE.Models;

public partial class Nacionalidad
{
    public string IdNacionalidad { get; set; } = null!;

    public string? Nacionalidad1 { get; set; }

    public virtual ICollection<Autor> Autors { get; set; } = new List<Autor>();
}
