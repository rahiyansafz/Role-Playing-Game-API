using Microsoft.AspNetCore.Mvc;

namespace Role_Playing_Game_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FightController : ControllerBase
{
    private readonly IFightRepository _fightService;
    public FightController(IFightRepository fightService)
    {
        _fightService = fightService;
    }

    [HttpPost("Weapon")]
    public async Task<ActionResult<ApiResponse<AttackResultDto>>> WeaponAttack(WeaponAttackDto request)
    {
        return Ok(await _fightService.WeaponAttack(request));
    }

    [HttpPost("Skill")]
    public async Task<ActionResult<ApiResponse<AttackResultDto>>> SkillAttack(SkillAttackDto request)
    {
        return Ok(await _fightService.SkillAttack(request));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<FightResultDto>>> Fight(FightRequestDto request)
    {
        return Ok(await _fightService.Fight(request));
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<HighscoreDto>>>> GetHighscore()
    {
        return Ok(await _fightService.GetHighscore());
    }
}