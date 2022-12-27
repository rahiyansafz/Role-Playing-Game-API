namespace Role_Playing_Game_API.Models.Fight;

public class FightRequestDto
{
    public List<int> CharacterIds { get; set; } = new List<int>();
}