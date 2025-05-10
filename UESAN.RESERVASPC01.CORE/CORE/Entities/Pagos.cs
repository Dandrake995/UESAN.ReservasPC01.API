using System;
using System.Collections.Generic;

namespace UESAN.RESERVASPC01.CORE.CORE.Entities;

public partial class Pagos
{
    public int Id { get; set; }

    public int ReservaId { get; set; }

    public DateTime FechaPago { get; set; }

    public decimal Monto { get; set; }

    public string MetodoPago { get; set; } = null!;

    public virtual Reservas Reserva { get; set; } = null!;
}
