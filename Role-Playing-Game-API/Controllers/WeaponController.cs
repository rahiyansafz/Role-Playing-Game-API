using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Role_Playing_Game_API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class WeaponController : ControllerBase
{
    private readonly IWeaponRepository _weaponService;
    public WeaponController(IWeaponRepository weaponService)
    {
        _weaponService = weaponService;
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<GetCharacterDto>>> AddWeapon(AddWeaponDto newWeapon)
    {
        return Ok(await _weaponService.AddWeapon(newWeapon));
    }
}