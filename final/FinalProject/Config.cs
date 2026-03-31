using System.Text.Json.Serialization;

class Config
{
    private int _players;
    private Deck _deck;
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