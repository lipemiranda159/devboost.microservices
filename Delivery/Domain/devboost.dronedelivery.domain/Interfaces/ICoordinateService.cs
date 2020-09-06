using devboost.dronedelivery.felipe.domain.core;

namespace devboost.dronedelivery.domain.Interfaces
{
    public interface ICoordinateService
    {
        double GetKmDistance(Point originPoint, Point destPoint);
    }
}
