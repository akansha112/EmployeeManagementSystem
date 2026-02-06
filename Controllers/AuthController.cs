using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Entities.DTOs;
using EmployeeManagementSystem.Repository.Interfaces;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser>userManager;
        private readonly ITokenRepository repository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository repository)

        {
            this.userManager = userManager;
            this.repository = repository;
        }

        //POST: /api/Auth/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequeatDto dto)
        {
            var identityUser = new IdentityUser
            {
                UserName = dto.userName,
                Email = dto.userName
            }; 
            var result=await userManager.CreateAsync(identityUser, dto.Password);
            if (result.Succeeded)
            {
                //Add roles to user
                if (dto.Roles != null && dto.Roles.Length > 0)
                {
                 result=   await userManager.AddToRolesAsync(identityUser, dto.Roles);
                 if(result.Succeeded)
                    {
                        return Ok("User registered successfully with roles");
                    }
                                    }

            }
            return BadRequest("User registration failed");
        }

        //POST: /api/Auth/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginRequestDto dto)
        {
          var users=  await userManager.FindByEmailAsync(dto.userName);
            if(users != null)
                {
                    var passwordValid=await userManager.CheckPasswordAsync(users, dto.Password);
                    if(passwordValid)
                    {
                    //create tokin and return to client
                    var roles=await userManager.GetRolesAsync(users);
                    if (roles != null)
                    {
                        var jwtToken=repository.CreateJWTToken(users, roles.ToList());
                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken,
                        };
                        return Ok(response);
                    }
                    
                    
                    
                    }
                }
                return BadRequest("Invalid username or password");


        }
    } 
}
