using System.Threading.Tasks;
using Ubus.Business.Entities;

namespace Ubus.Business.Interfaces.Services
{
    public interface ITripService : IBaseService<Trip>
    {
        Task UpdateAllTripsFinished();
    }
}
