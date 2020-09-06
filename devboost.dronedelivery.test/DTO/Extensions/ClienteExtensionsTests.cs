using devboost.dronedelivery.felipe.DTO.Extensions;
using Xunit;

namespace devboost.dronedelivery.test.DTO.Extensions
{
    public class ClienteExtensionsTests
    {
        [Fact]
        public void ClienteHasUserTest()
        {
            var cliente = SetupTests.GetLogin();
            Assert.True(cliente.HasClient());
        }
    }
}
