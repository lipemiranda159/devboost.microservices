using devboost.dronedelivery.felipe.domain.core.Models;

namespace devboost.dronedelivery.felipe.domain.core
{
    public sealed class DroneStatusDto
    {
        public DroneStatusDto()
        {

        }

        public DroneStatusDto(Drone d)
        {
            Drone = d;
        }

        public Drone Drone { get; set; }

        public int SomaPeso { get; set; }
        public int SomaDistancia { get; set; }
    }
}
