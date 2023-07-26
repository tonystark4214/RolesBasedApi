using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Project220723.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project220723.Repository
{
    public class LoginClass:InterfaceLogin
    {
        public readonly sdirectdbContext dbContext;
        private readonly IConfiguration config;
        public LoginClass(sdirectdbContext dbContext, IConfiguration _config)
        {
            this.dbContext=dbContext;
            config = _config;
        }

        //authentication by checking database
        public string GetCredentials(Credentials cred)
        {
            var data = dbContext.PraveenLoginCredentials.Where(i => i.UserName == cred.Username && i.Password == cred.Password && i.IsDeleted!=true).FirstOrDefault();
            if (data != null)
            {
                return cred.Username;
            }
            else
            {
                return "error";
            }
        }


        //token generation
        public ResponseModel GenerateJSONWebToken(string Username)
        {
            ResponseModel responseModel = new ResponseModel();
            var role = (from log in dbContext.PraveenLoginCredentials
                        join roleMap in dbContext.PraveenUserRoleMappers
                      on log.UserId equals roleMap.UserId
                        join roles in dbContext.PraveenRoles on roleMap.RoleId equals roles.RoleId
                        where log.UserName == Username
                        select new RolesModel
                        {
                            RoleName = roles.RolesName
                        }).ToList();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
             new Claim(ClaimTypes.Name, Username),
             //new Claim(ClaimTypes.Email, "admin@gmail.com"),
             //new Claim(ClaimTypes.Sid, "101"),

             //new Claim(ClaimTypes.Role ,role.RoleName)
            };
            if (role != null)
            {
                foreach(var u in role)
                {
                    claims.Add(new Claim(ClaimTypes.Role, u.RoleName));
                }
            }

            var token = new JwtSecurityToken(config["Jwt:Issuer"],
              config["Jwt:Audience"], claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);
            Token token1 = new Token();
            token1.token = new JwtSecurityTokenHandler().WriteToken(token);
            responseModel.token = token1.token;
            responseModel.Roles = role;
            return responseModel;
        }
    }
}

