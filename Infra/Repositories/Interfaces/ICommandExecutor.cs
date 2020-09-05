using System.Collections.Generic;

namespace devboost.dronedelivery.felipe.EF.Repositories.Interfaces
{
    public interface ICommandExecutor<T> where T : class
    {
        IEnumerable<T> ExcecuteCommand(string command);
    }
}
