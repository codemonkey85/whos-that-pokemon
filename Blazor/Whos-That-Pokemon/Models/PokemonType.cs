namespace Whos_That_Pokemon.Models;

public class PokemonType
{
    public int Slot { get; set; }

    public TypeEntity? Type { get; set; }

    public override string ToString() => JsonSerializer.Serialize(this);
}
