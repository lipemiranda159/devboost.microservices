using devboost.dronedelivery.felipe.DTO.Extensions;
using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.felipe.Security.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.Security
{
    public class AccessManager
    {
        private readonly SigningConfigurations _signingConfigurations;
        private readonly TokenConfigurations _tokenConfigurations;
        private readonly ILoginValidator _loginValidator;
        public AccessManager(
            SigningConfigurations signingConfigurations,
            TokenConfigurations tokenConfigurations,
            ILoginValidator loginValidator)
        {
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _loginValidator = loginValidator;
        }

        public async Task<bool> ValidateCredentials(Cliente user)
        {
            bool credenciaisValidas = false;
            if (user.HasClient())
            {
                var userIdentity = await _loginValidator.GetUserById(user.UserId);
                if (userIdentity != null)
                {
                    var resultadoLogin = await _loginValidator.CheckPasswordUserAsync(userIdentity, user.Password);
                    if (resultadoLogin)
                    {
                        credenciaisValidas = await _loginValidator.ValidateRoleAsync(
                            userIdentity, Roles.ROLE_API_DRONE);
                    }
                }
            }

            return credenciaisValidas;
        }

        public Token GenerateToken(Cliente user)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.UserId, "Login"),
                new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserId)
                }
            );

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao +
                TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });
            var token = handler.WriteToken(securityToken);

            return new Token()
            {
                Authenticated = true,
                Created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                Expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                AccessToken = token,
                Message = "OK"
            };
        }
    }
}
