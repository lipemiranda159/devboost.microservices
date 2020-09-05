using devboost.dronedelivery.felipe.DTO.Models;

namespace devboost.dronedelivery.felipe.DTO.Extensions
{
    public static class ClienteExtensions
    {
        public static bool HasClient(this Cliente cliente)
        {
            return cliente != null && !string.IsNullOrWhiteSpace(cliente.UserId);
        }
    }
}
