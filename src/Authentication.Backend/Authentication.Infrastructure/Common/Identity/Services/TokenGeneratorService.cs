using Authentication.Application.Common.Constants;
using Authentication.Application.Common.Identity.Services;
using Authentication.Application.Common.Settings;
using Authentication.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.Infrastructure.Common.Identity.Services;

public class TokenGeneratorService : ITokenGeneratorService
{
    private readonly JwtSettings _jwtSettings;

    public TokenGeneratorService(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }
    public string GetToken(User user)
    {
        var jwtToken = GetJwtToken(user);
        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        return token;
    }
    public JwtSecurityToken GetJwtToken(User user)
    {
        var claims = GetClaims(user);
        var secureKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var credentials = new SigningCredentials(secureKey, SecurityAlgorithms.HmacSha256);

        return new JwtSecurityToken
            (
            issuer: _jwtSettings.ValidIssuer,
            audience: _jwtSettings.ValidAudience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationInMinutes),
            signingCredentials: credentials
            );
    }
    public List<Claim> GetClaims(User user)
    {
        return new List<Claim>
        {
            new(ClaimTypes.Email, user.EmailAddress),
            new(ClaimConstant.UserId, user.Id.ToString())
        };
    }
}

