namespace Role_Playing_Game_API.Contracts;

public interface IWeaponRepository
{
    Task<ApiResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);
}