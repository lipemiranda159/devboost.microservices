using devboost.dronedelivery.felipe.domain.core.Models;

namespace devboost.dronedelivery.felipe.domain.core.Extensions
{
    public static class PedidoExtensions
    {
        public static Point GetPoint(this Pedido pedido)
        {
            return new Point(pedido.Cliente.Latitude, pedido.Cliente.Longitude);
        }
    }
}
