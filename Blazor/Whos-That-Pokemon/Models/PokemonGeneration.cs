namespace Whos_That_Pokemon.Models;

public class PokemonGeneration
{
    public string? Name { get; set; }

    public string? Url { get; set; }

    public override string ToString() => JsonSerializer.Serialize(this);
}
