using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.Security.Interfaces
{
    public interface IDroneRoleValidator
    {
        Task<bool> ExistRoleAsync(string role);
        Task<bool> CreateRoleAsync(string role);
    }
}
