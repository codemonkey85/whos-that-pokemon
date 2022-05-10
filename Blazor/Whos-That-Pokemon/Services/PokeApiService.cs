namespace Whos_That_Pokemon.Services;

public record PokeApiService(HttpClient HttpClient)
{
    private readonly Random random = new();

    public async Task<(Pokemon Pokemon, PokemonSpecies PokemonSpecies)> GetPokemonInfo(int? id = null)
    {
        if (id is null)
        {
            id = random.Next(1, 898);
        }

        var pokemon = await HttpClient.GetFromJsonAsync<Pokemon>($"https://pokeapi.co/api/v2/pokemon/{id}");
        if (pokemon is null)
        {
            throw new Exception($"{nameof(Pokemon)} is null");
        }

        var pokemonSpecies = await HttpClient.GetFromJsonAsync<PokemonSpecies>($"https://pokeapi.co/api/v2/pokemon-species/{id}");
        if (pokemonSpecies is null)
        {
            throw new Exception($"{nameof(PokemonSpecies)} is null");
        }

        return (pokemon, pokemonSpecies);
    }

    public static string GetTypeColor(string? typeName) => typeName switch
    {
        null => string.Empty,
        "normal" => "#aaaa99",
        "fire" => "#ff4322",
        "water" => "#3499fe",
        "electric" => "#ffcc33",
        "grass" => "#76cc55",
        "ice" => "#65cdff",
        "fighting" => "#bb5544",
        "poison" => "#aa5599",
        "ground" => "#ddbb55",
        "flying" => "#8493f7",
        "psychic" => "#ff5599",
        "bug" => "#aabb23",
        "rock" => "#bbaa66",
        "ghost" => "#6666bb",
        "dragon" => "#7466eb",
        "dark" => "#775544",
        "steel" => "#aaaabb",
        "fairy" => "#ee9aee",
        _ => string.Empty
    };

    public static string GetGenerationPrettyName(string? genName)
    {
        var genNum = genName switch
        {
            null => 0,
            "generation-i" => 1,
            "generation-ii" => 2,
            "generation-iii" => 3,
            "generation-iv" => 4,
            "generation-v" => 5,
            "generation-vi" => 6,
            "generation-vii" => 7,
            "generation-viii" => 8,
            _ => 0
        };
        return $"Gen {genNum}";
    }
}
