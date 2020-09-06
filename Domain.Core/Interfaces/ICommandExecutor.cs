using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.dronedelivery.domain.core.Interfaces
{
    public interface ICommandExecutor<T> where T : class
    {
        IEnumerable<T> ExcecuteCommand(string command);
        Task ExecuteCommandAsync(string command);
    }
}
