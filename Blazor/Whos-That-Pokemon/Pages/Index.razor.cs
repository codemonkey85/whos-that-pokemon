namespace Whos_That_Pokemon.Pages;

public partial class Index
{
    private readonly GameModel gameModel = new();

    private (Pokemon Pokemon, PokemonSpecies PokemonSpecies)? PokemonData;

    private IDictionary<string, object> NewPokemonButtonAttributes = new Dictionary<string, object>
    {
        ["type"] = "button",
        ["class"] = "btn",
    };

    private IDictionary<string, object> SubmitButtonAttributes = new Dictionary<string, object>
    {
        ["id"] = "btn-checkAnswer",
        ["type"] = "submit",
        ["class"] = "btn disabled",
        ["disabled"] = string.Empty,
    };

    private IDictionary<string, object> UserInputAttributes = new Dictionary<string, object>
    {
        ["type"] = "text",
        ["class"] = "user-answer disabled",
        ["disabled"] = string.Empty,
        ["placeholder"] = "Pokémon name",
    };

    private IDictionary<string, object> IdkButtonAttributes = new Dictionary<string, object>
    {
        ["id"] = "btn-idk",
        ["type"] = "button",
        ["class"] = "disabled",
        ["disabled"] = string.Empty,
    };

    private string? PokemonName =>
        PokemonData?.Pokemon?.Name;

    private string? PrettyGenName =>
        PokeApiService.GetGenerationPrettyName(PokemonData?.PokemonSpecies?.Generation?.Name);

    private (string? Name, string? Color)? Type1NameColor =>
        (PokemonData?.Pokemon?.Types?.Length ?? 0) < 1
            ? null
            : (PokemonData?.Pokemon?.Types?[0]?.Type?.Name, PokeApiService.GetTypeColor(PokemonData?.Pokemon?.Types?[0]?.Type?.Name));

    private (string? Name, string? Color)? Type2NameColor =>
        (PokemonData?.Pokemon?.Types?.Length ?? 0) < 2
            ? null
            : (PokemonData?.Pokemon?.Types?[1]?.Type?.Name, PokeApiService.GetTypeColor(PokemonData?.Pokemon?.Types?[1]?.Type?.Name));

    private string? PokemonArtworkUrl =>
        PokemonData?.Pokemon?.Sprites?.Other?.OfficialArtwork?.FrontDefault;

    private bool Correct =>
        !string.IsNullOrEmpty(gameModel.UserInput) && string.Equals(gameModel.UserInput, PokemonData?.Pokemon?.Name);

    private async Task FetchPokemon()
    {
        ResetVisibility();
        ResetColors();
        PokemonData = await PokeApiService.GetPokemonInfo();
        if (PokemonData is null)
        {
            Console.WriteLine($"{nameof(PokemonData)} is null");
            return;
        }
        EnableButtons();
    }

    private void DontKnow()
    {
        /*
            document.querySelector('.play-area .answer-area').classList.add('incorrect');
        */
        ShowAnswer();
        DisableButtons();
    }

    private void HandleSubmit()
    {
        if (string.IsNullOrEmpty(gameModel.UserInput))
        {
            return;
        }
        /*
              let user = document.querySelector('.user-answer').value;
              let answer = document.querySelector('.answer').innerText;
              if (user.toLowerCase() === answer.toLowerCase()) { // If answer correct
                resetColors();
                document.querySelector('.play-area .answer-area').classList.add('correct');
                showAnswer();
                disableBtns();
              } else { // If answer incorrect
                document.querySelector('.play-area .answer-area').classList.add('incorrect');
                document.querySelector('.user-answer').value = "Try again!";
              }
         */
    }

    private void DisableButtons()
    {
        IdkButtonAttributes.TryAdd("disabled", string.Empty);
        SubmitButtonAttributes.TryAdd("disabled", string.Empty);
        UserInputAttributes.TryAdd("disabled", string.Empty);
        IdkButtonAttributes["class"] = "disabled";
        SubmitButtonAttributes["class"] = "btn disabled";
    }

    private void EnableButtons()
    {
        IdkButtonAttributes.Remove("disabled");
        SubmitButtonAttributes.Remove("disabled");
        UserInputAttributes.Remove("disabled");
        IdkButtonAttributes["class"] = string.Empty;
        SubmitButtonAttributes["class"] = "btn";
    }

    private void ShowAnswer()
    {
        /*
            document.querySelector('#pokemon').classList.remove('silhouette');
            document.querySelector('.answer').classList.remove('hidden');
            document.querySelector('.user-answer').classList.add('hidden');
            document.querySelector('.pokemon-data').classList.remove('invisible');
        */
    }

    private void ResetVisibility()
    {
        /*
            document.querySelector('.pokemon-data').classList.add('invisible');
            document.querySelector('#pokemon').classList.add('silhouette'); // Hide image
            document.querySelector('.answer').classList.add('hidden'); // Hide answer
            document.querySelector('.user-answer').classList.remove('hidden'); // Unhide user input
            document.querySelector('.user-answer').value = ""; // Reset input to blank
            document.querySelector('.user-answer').focus(); // Automatically select user input box
        */
    }

    private void ResetColors()
    {
        /*
            document.querySelector('.play-area .answer-area').classList.remove('correct');
            document.querySelector('.play-area .answer-area').classList.remove('incorrect');
        */
    }

    private void ClearInput()
    {
        if (string.Equals(gameModel.UserInput, "Try again!"))
        {
            gameModel.UserInput = string.Empty;
        }
    }
}

/*
    // Get new pokemon from pokeapi
    function getPoke(){
      document.querySelector('h2').innerText = "";
      document.querySelector('.types').innerHTML = "";

            let name = data.species.name;
            document.querySelector('h2').innerText = name[0].toUpperCase() + name.slice(1); // Update answer
            document.querySelector('img').src = data.sprites.other['official-artwork'].front_default; // Update image

            data.types.forEach(obj => {
              const li = document.createElement('li');
              li.textContent = obj.type.name.toUpperCase();
              li.classList.add("data");
              li.style.backgroundColor = `#${typeColors[obj.type.name.toLowerCase()]}`;
              document.querySelector('.types').appendChild(li)
            })
          })
      
      fetch(`https://pokeapi.co/api/v2/pokemon-species/${randomID}`)
          .then(res => res.json()) // parse response as JSON
          .then(data => {
            let gen = genDict[data.generation.name];
            document.querySelector('.generation').innerText = `Gen ${gen}`;
          })
    }
*/
