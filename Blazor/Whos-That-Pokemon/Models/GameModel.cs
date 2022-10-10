namespace Whos_That_Pokemon.Models;

public class GameModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Must enter a Pokémon name"), MinLength(1)]
    public string UserInput { get; set; } = default!;
}
