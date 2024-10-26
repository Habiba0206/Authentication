using Authentication.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Authentication.Application.Common.Identity.Services;

public interface ITokenGeneratorService
{
    string GetToken(User user);
    JwtSecurityToken GetJwtToken(User user);
    List<Claim> GetClaims(User user);
}
