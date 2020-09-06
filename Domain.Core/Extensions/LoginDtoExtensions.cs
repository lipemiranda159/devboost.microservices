namespace devboost.dronedelivery.felipe.domain.core.Extensions
{
    public static class LoginDtoExtensions
    {
        public static bool HasClient(this LoginDTO cliente)
        {
            return cliente != null && !string.IsNullOrWhiteSpace(cliente.UserId);
        }
    }
}
