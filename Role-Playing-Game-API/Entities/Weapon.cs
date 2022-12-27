namespace Role_Playing_Game_API.Entities;

public class Weapon
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Damage { get; set; }
    public Character? Character { get; set; }
    public int CharacterId { get; set; }
}