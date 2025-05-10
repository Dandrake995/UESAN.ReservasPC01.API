using System;
using System.Collections.Generic;

namespace UESAN.RESERVASPC01.CORE.CORE.Entities;

public partial class VwReservasDetalle
{
    public int ReservaId { get; set; }

    public string Cliente { get; set; } = null!;

    public string Cancha { get; set; } = null!;

    public string TipoCancha { get; set; } = null!;

    public DateOnly Fecha { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public decimal? MontoPagado { get; set; }

    public string? MetodoPago { get; set; }

    public decimal? TarifaPorHora { get; set; }
}
