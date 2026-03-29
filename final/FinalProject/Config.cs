using System.Text.Json.Serialization;

class Config
{
    private int _players;
    private Deck _deck;
    private int _rounds;

    public Config(int p, Deck d, int r)
    {
        _players = p;
        _deck = d;
        _rounds = r;
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
    public int GetRounds()
    {
        return _rounds;
    }

}