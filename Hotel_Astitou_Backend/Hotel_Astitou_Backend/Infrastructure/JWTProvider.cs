using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Hotel_Astitou_Backend.Model;

using Microsoft.IdentityModel.Tokens;

namespace MantaxHotel.Infrastructure
{
    public class JWTProvider
    {
        // TOOD: use appsettings
        private static readonly string SecretKey = "Rw00HMN4gqwWUMMBrHGYQANastYtl8Dn6";
        public static readonly byte[] SecretKeyBytes = Encoding.ASCII.GetBytes(SecretKey);
        private static readonly JwtSecurityTokenHandler JwtSecurityTokenHandler = new JwtSecurityTokenHandler();

        public static string GenerateJWT(User user)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                }),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(SecretKeyBytes),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            return JwtSecurityTokenHandler.WriteToken(
                JwtSecurityTokenHandler.CreateToken(tokenDescriptor)
            );
        }

        public static User DecryptJWT(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(SecretKeyBytes),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            var claims = handler.ValidateToken(token, validations, out var tokenSecure);

            return new User
            {
                Id = int.Parse(claims.Claims.Single(x => x.Type == ClaimTypes.Name).Value),

                Token = token,
            };
        }
    }
}