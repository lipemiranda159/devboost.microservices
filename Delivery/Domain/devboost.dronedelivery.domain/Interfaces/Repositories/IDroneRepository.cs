using devboost.dronedelivery.domain.core;
using devboost.dronedelivery.domain.core.Entities;
using devboost.dronedelivery.domain.core.Interfaces;
using System.Collections.Generic;

namespace devboost.dronedelivery.domain.Interfaces.Repositories
{
    public interface IDroneRepository : IRepositoryBase<Drone>
    {
        Drone RetornaDrone();
        List<StatusDroneDto> GetDroneStatus();
        DroneStatusDto RetornaDroneStatus(int droneId);
    }
}
