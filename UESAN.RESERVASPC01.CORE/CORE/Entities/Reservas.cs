using System;
using System.Collections.Generic;

namespace UESAN.RESERVASPC01.CORE.CORE.Entities;

public partial class Reservas
{
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public int ClienteId { get; set; }

    public int CanchaId { get; set; }

    public virtual Canchas Cancha { get; set; } = null!;

    public virtual Clientes Cliente { get; set; } = null!;

    public virtual ICollection<Pagos> Pagos { get; set; } = new List<Pagos>();
}
