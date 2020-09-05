using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.DTO.Models;
using System.Collections.Generic;

namespace devboost.dronedelivery.felipe.Facade.Interface
{
    public interface IDroneFacade
    {
        List<StatusDroneDto> GetDroneStatusAsync();
        public Drone SaveDrone(Drone drone);
    }
}
