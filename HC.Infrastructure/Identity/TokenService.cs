using HC.Application.Common.Interfaces;
using HC.Domain.Common;
using HC.Domain.Dto.Responses;
using HC.Infrastructure.Auth.Jwt;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HC.Infrastructure.Identity;

public class JwtService : ITokenService
{
    private SigningCredentials? _credentials;
    private SymmetricSecurityKey? _securityKey;
    private readonly JwtSettings _jwtSettings;

    public JwtService(JwtSettings jwtSettings)
    {
        _jwtSettings = jwtSettings;
        SetupCredentials();
    }

    private void SetupCredentials()
    {
        _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.IssuerSigningKey));
        _credentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);
    }
    public string GetToken(UserResponse user)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.IssuerSigningKey));
        var _TokenExpiryTimeInHour = Convert.ToInt64(_jwtSettings.RequireExpirationTime);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _jwtSettings.ValidIssuer,
            Audience = _jwtSettings.ValidAudience,
            //Expires = DateTime.UtcNow.AddHours(_TokenExpiryTimeInHour),
            Expires = DateTime.UtcNow.AddMinutes(1),
            SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role),
            })
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    private JwtSecurityToken GenerateTokenByClaims(IEnumerable<Claim> claims, DateTime expires)
    {
        return new JwtSecurityToken(_jwtSettings.ValidIssuer,
            _jwtSettings.ValidAudience,
            claims,
            expires: expires,
            signingCredentials: _credentials);
    }

    public IEnumerable<Claim> DecodeAndValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _securityKey,
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            return jwtToken.Claims;
        }
        catch
        {
            return null;
        }
    }
}

