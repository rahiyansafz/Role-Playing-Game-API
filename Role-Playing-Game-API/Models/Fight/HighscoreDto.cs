namespace Role_Playing_Game_API.Models.Fight;

public class HighscoreDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Fights { get; set; }
    public int Victories { get; set; }
    public int Defeats { get; set; }
}