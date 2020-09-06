using devboost.dronedelivery.felipe.domain.core;
using devboost.dronedelivery.felipe.domain.core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.dronedelivery.domain.Interfaces
{
    public interface IDroneService
    {
        Task<DroneStatusDto> GetAvailiableDroneAsync(double distance, Pedido pedido);
        List<StatusDroneDto> GetDroneStatusAsync();

    }
}
