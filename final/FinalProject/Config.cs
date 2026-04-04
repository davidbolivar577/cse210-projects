using System.Text.Json;
using System.Text.Json.Serialization;

class Config
{
    [JsonInclude]
    private int _players;
    [JsonInclude]
    private Deck _deck;
    [JsonInclude]
    private int _games;

    public Config(int p, Deck d, int g)
    {
        _players = p;
        _deck = d;
        _games = g;
    }

    [JsonConstructor]
    public Config()
    {
        
    }

    public string Save()
    {
        return JsonSerializer.Serialize(this);
    }
    
    public int GetPlayers()
    {
        return _players;
    }
    
    public Deck GetDeck()
    {
        return _deck;
    }
    public int GetGames()
    {
        return _games;
    }

}