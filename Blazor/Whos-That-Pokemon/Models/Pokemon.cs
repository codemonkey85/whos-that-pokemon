namespace Whos_That_Pokemon.Models;

public class Pokemon
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public PokemonSprites? Sprites { get; set; }

    public PokemonType[]? Types { get; set; }

    public override string ToString() => JsonSerializer.Serialize(this);
}
