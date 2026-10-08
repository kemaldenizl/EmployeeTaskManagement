using System.IdentityModel.Tokens.Jwt;
using EmployeeTaskManagement.Core.Entities.Concrete;
using EmployeeTaskManagement.Core.Utilities.Security.Encyption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeTaskManagement.Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
		private TokenOptions _tokenOptions;
		private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration){
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
			_accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }

        public AccessToken CreateToken(User user)
		{
			var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
			var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
			var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials);
			var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
			var token = jwtSecurityTokenHandler.WriteToken(jwt);

			return new AccessToken
			{
				Token = token,
				Expiration = _accessTokenExpiration
			};
		}

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials)
		{
			var jwt = new JwtSecurityToken(
				issuer:tokenOptions.Issuer,
				audience:tokenOptions.Audience,
				expires:_accessTokenExpiration,
				notBefore:DateTime.Now,
				signingCredentials: signingCredentials
			);
			return jwt;
		}
    }
}