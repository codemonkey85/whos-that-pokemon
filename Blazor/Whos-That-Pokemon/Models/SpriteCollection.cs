namespace Whos_That_Pokemon.Models;

public class SpriteCollection
{
    [JsonPropertyName("front_default")]
    public string? FrontDefault { get; set; }

    public override string ToString() => JsonSerializer.Serialize(this);
}
