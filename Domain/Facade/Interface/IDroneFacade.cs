using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.Facade.Interface
{
    public interface IDroneFacade
    {
        List<StatusDroneDto> GetDroneStatus();
        public Task<Drone> SaveDroneAsync(Drone drone);
    }
}
