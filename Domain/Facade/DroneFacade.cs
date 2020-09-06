using devboost.dronedelivery.felipe.Facade.Interface;
using devboost.dronedelivery.felipe.Services.Interfaces;
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
            drone.Perfomance = (drone.Autonomia / 60.0f) * drone.Velocidade;

            await _droneRepository.SaveDroneAsync(drone);

            return drone;
        }

    }
}
