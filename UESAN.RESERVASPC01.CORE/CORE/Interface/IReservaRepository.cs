using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.ReservasPC01.API.Infrastructure.Data;
using UESAN.RESERVASPC01.CORE.CORE.Entities;

namespace UESAN.RESERVASPC01.CORE.CORE.Interface
{
    internal interface IReservaRepository
    {
        Task<bool> AddReserva(Reservas reserva);
        Task<bool> UpdateReserva(Reservas reserva);
        Task<bool> DeleteReserva(int id);
        Task<Reserva> GetReservaById(int id);
        Task<List<Reserva>> GetAllReservas();
        Task<List<Reserva>> GetReservasByDate(DateTime date);
        Task<List<Reserva>> GetReservasByUserId(int userId);
    }
}
