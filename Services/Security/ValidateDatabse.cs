using devboost.dronedelivery.felipe.EF.Data;
using devboost.dronedelivery.felipe.Security.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace devboost.dronedelivery.felipe.Security
{
    [ExcludeFromCodeCoverage]
    public class ValidateDatabse : IValidateDatabase
    {
        public ValidateDatabse()
        {
        }
        public bool EnsureCreated()
        {
            return true;
        }
    }
}
