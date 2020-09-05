using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.DTO.Models;
using System.Collections.Generic;

namespace devboost.dronedelivery.felipe.EF.Repositories.Interfaces
{
    public interface IDroneRepository
    {
        List<StatusDroneDto> GetDroneStatusAsync();
        DroneStatusDto RetornaDroneStatus(int droneId);
        Drone RetornaDrone();
        void SaveDrone(Drone drone);
        Drone GetDrone(int id);
    }
}
