using System.Text.Json.Serialization;

namespace Role_Playing_Game_API.Entities;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RpgClass
{
    Knight = 1,
    Mage = 2,
    Cleric = 3
}