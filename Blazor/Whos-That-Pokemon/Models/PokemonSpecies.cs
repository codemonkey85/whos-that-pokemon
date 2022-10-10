namespace Whos_That_Pokemon.Models;

public class PokemonSpecies
{
    public int Id { get; set; }

    public PokemonGeneration? Generation { get; set; }

    public override string ToString() => JsonSerializer.Serialize(this);
}
