using CaminhadasAPI.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CaminhadasAPI.Controllers; 

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase {
    private readonly UserManager<IdentityUser> _userManager;

    public AuthController(UserManager<IdentityUser> userManager) {
        _userManager = userManager;
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
}