using Microsoft.AspNetCore.Mvc;

using Role_Playing_Game_API.Models.User;

namespace Role_Playing_Game_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthManager _authRepo;

    public AuthController(IAuthManager authRepo)
    {
        _authRepo = authRepo;
    }

    [HttpPost("Register")]
    public async Task<ActionResult<ApiResponse<int>>> Register(Register request)
    {
        var response = await _authRepo.Register(
            new User { Username = request.Username }, request.Password
        );
        if (!response.Success)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpPost("Login")]
    public async Task<ActionResult<ApiResponse<int>>> Login(Login request)
    {
        var response = await _authRepo.Login(request.Username, request.Password);
        if (!response.Success)
            return BadRequest(response);

        return Ok(response);
    }
}