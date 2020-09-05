using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.felipe.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.Controllers
{

    /// <summary>
    /// Controller com operações referentes aos drones
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController
    {
        private readonly AccessManager _accessManager;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public LoginController(AccessManager accessManager)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            _accessManager = accessManager;
        }

        [AllowAnonymous]
        [HttpPost]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public async Task<object> Post([FromBody] Cliente usuario)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            if (await _accessManager.ValidateCredentials(usuario))
            {
                return _accessManager.GenerateToken(usuario);
            }
            else
            {
                return new
                {
                    Authenticated = false,
                    Message = "Falha ao autenticar"
                };
            }
        }


    }
}
