namespace Whos_That_Pokemon.Models;

public class OtherSprites
{
    [JsonPropertyName("official-artwork")]
    public SpriteCollection? OfficialArtwork { get; set; }

    public override string ToString() => JsonSerializer.Serialize(this);
}
