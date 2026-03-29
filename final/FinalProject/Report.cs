using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

class Report
{
    private Deck _deckUsed;
    private int _players;
    private List<int> _playerWins;
    private int _rounds;

    public Report(Deck d, int p, int r)
    {
        _deckUsed = d;
        _players = p;
        _playerWins = [.. new int[p]];
        _rounds = r;
    }

    [JsonConstructor]
    public Report()
    {
        
    }

    public void Display()
    {
        
    }

    public void Append(List<int> wins, int rounds)
    {
        _playerWins.Zip(wins, (a, b) => a + b).ToList<int>();
        _rounds += rounds;
    }
}