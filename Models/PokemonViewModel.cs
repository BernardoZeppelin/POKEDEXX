
using System.Text.Json.Serialization;

public class PokemonViewModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }


    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    [JsonPropertyName("sprites")]
    public PokemonSprites Sprites { get; set; }
}

public class PokemonSprites //imagem de frente
{
    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }
}