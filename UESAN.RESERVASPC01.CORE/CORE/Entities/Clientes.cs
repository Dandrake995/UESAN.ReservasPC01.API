using System;
using System.Collections.Generic;

namespace UESAN.RESERVASPC01.CORE.CORE.Entities;

public partial class Clientes
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
}
