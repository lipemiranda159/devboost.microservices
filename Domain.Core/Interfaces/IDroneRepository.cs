using devboost.dronedelivery.felipe.domain.core;
using devboost.dronedelivery.felipe.domain.core.Models;
using System.Collections.Generic;

namespace devboost.dronedelivery.domain.core.Interfaces
{
    public interface IDroneRepository : IRepositoryBase<Drone>
    {
        List<StatusDroneDto> GetDroneStatusAsync();
        DroneStatusDto RetornaDroneStatus(int droneId);
        Drone RetornaDrone();
    }
}
