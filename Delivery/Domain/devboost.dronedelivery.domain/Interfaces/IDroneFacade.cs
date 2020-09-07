using devboost.dronedelivery.domain.core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.dronedelivery.domain.Interfaces
{
    public interface IDroneFacade
    {
        List<StatusDroneDto> GetDroneStatus();
        public Task<Drone> SaveDroneAsync(Drone drone);
    }
}
