using System;
using System.Collections.Generic;

namespace UESAN.RESERVASPC01.CORE.CORE.Entities;

public partial class Canchas
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string Ubicacion { get; set; } = null!;

    public virtual ICollection<HorariosDisponibles> HorariosDisponibles { get; set; } = new List<HorariosDisponibles>();

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();

    public virtual Tarifas? Tarifas { get; set; }
}
