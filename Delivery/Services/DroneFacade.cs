using devboost.dronedelivery.domain.core.Interfaces;
using devboost.dronedelivery.domain.core.Models;
using devboost.dronedelivery.domain.Entites;
using devboost.dronedelivery.domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.Facade
{
    public class DroneFacade : IDroneFacade
    {
        private readonly IDroneService _droneService;
        private readonly IDroneRepository _droneRepository;
        public DroneFacade(IDroneService droneService, IDroneRepository droneRepository)
        {
            _droneService = droneService;
            _droneRepository = droneRepository;
        }
        public List<StatusDroneDto> GetDroneStatus()
        {
            return _droneService.GetDroneStatusAsync().ToList();
        }

        public async Task<Drone> SaveDroneAsync(Drone drone)
        {
            await _droneRepository.UpdateAsync(drone);

            return drone;
        }

    }
}
