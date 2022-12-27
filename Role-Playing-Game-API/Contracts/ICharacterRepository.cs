namespace Role_Playing_Game_API.Contracts;

public interface ICharacterRepository
{
    Task<ApiResponse<List<GetCharacterDto>>> GetAllCharacters();
    Task<ApiResponse<GetCharacterDto>> GetCharacterById(int id);
    Task<ApiResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
    Task<ApiResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter);
    Task<ApiResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
    Task<ApiResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill);
}