using devboost.dronedelivery.felipe.DTO.Models;

namespace devboost.dronedelivery.felipe.DTO.Extensions
{
    public static class LoginDtoExtensions
    {
        public static bool HasClient(this LoginDTO cliente)
        {
            return cliente != null && !string.IsNullOrWhiteSpace(cliente.UserId);
        }
    }
}
