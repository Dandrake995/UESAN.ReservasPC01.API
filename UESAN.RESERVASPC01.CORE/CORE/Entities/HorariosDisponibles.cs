using System;
using System.Collections.Generic;

namespace UESAN.RESERVASPC01.CORE.CORE.Entities;

public partial class HorariosDisponibles
{
    public int Id { get; set; }

    public int CanchaId { get; set; }

    public byte DiaSemana { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public virtual Canchas Cancha { get; set; } = null!;
}
