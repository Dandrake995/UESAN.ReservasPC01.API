using System;
using System.Collections.Generic;

namespace UESAN.ReservasPC01.API.Infrastructure.Data;

public partial class Tarifas
{
    public int Id { get; set; }

    public int CanchaId { get; set; }

    public decimal PrecioHora { get; set; }

    public virtual Canchas Cancha { get; set; } = null!;
}
