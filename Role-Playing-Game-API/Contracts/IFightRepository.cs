namespace Role_Playing_Game_API.Contracts;

public interface IFightRepository
{
    Task<ApiResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto request);
    Task<ApiResponse<AttackResultDto>> SkillAttack(SkillAttackDto request);
    Task<ApiResponse<FightResultDto>> Fight(FightRequestDto request);
    Task<ApiResponse<List<HighscoreDto>>> GetHighscore();
}