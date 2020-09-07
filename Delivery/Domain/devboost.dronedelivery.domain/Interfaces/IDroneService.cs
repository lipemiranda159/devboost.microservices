using devboost.dronedelivery.domain.core;
using devboost.dronedelivery.domain.core.Entities;
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
