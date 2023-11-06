using CaminhadasAPI.Interfaces;
using CaminhadasAPI.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CaminhadasAPI.Controllers; 

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ITokenRepository _repo;

    public AuthController(UserManager<IdentityUser> userManager, ITokenRepository repo) {
        _userManager = userManager;
        _repo = repo;
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerRequestDto) {
        var identityUser = new IdentityUser() {
            UserName = registerRequestDto.Username,
            Email = registerRequestDto.Username,
            
        };
        var identityResult = await _userManager.CreateAsync(identityUser, registerRequestDto.Password);

        if (identityResult.Succeeded) {
            // adicionar roles para o usuário
            if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any()) {
                
                identityResult = await _userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                if (identityResult.Succeeded) {
                    return Ok("Usuário foi criado com sucesso");
                }
            }

        }

        return BadRequest("Algo deu errado");
    }
    
    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto) {
        var user = await _userManager.FindByEmailAsync(loginRequestDto.UserName);

        if (user != null) {
            var checkPasswordResult = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if (checkPasswordResult) {
                //Get Roles of user
                var roles = await _userManager.GetRolesAsync(user);
                if (roles != null) {
                    var jwtToken = _repo.CreateJwtToken(user, roles.ToList());

                    var response = new LoginResponseDto() {
                        JwtToken = jwtToken
                    };
                    return Ok(response);
                }
            }
        }
        return BadRequest("Usuário ou senha errados");
    }
}