namespace Whos_That_Pokemon.Models;

public class PokemonSprites
{
    public OtherSprites? Other { get; set; }

    public override string ToString() => JsonSerializer.Serialize(this);
}
