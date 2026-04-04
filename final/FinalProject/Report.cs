using System.Text.Json.Serialization;

class Report
{
    private Deck _deckUsed;
    private int _players;
    private int[] _playerWins;
    private int _games;
    private DateTime _created;

    public Report(Deck d, int p, int g)
    {
        _deckUsed = d;
        _players = p;
        _playerWins = new int[p];
        _games = g;
        _created = DateTime.Now;
    }

    [JsonConstructor]
    public Report()
    {
        
    }

    public void Display()
    {
        Console.WriteLine($"Report: Created {_created}");
        Console.WriteLine($"Number of players: {_players}");
        Console.WriteLine($"Number of rounds: {_games}\n");
        int greatest = -1;
        int least = -1;
        for(int i = 0; i < _playerWins.Length; i++)
        {
            //TODO redo greatest/least logic
            Console.WriteLine($"Wins of Player {i+1}: {_playerWins[i]}");//List every player win
            if(greatest == -1 || _playerWins[i] > _playerWins[greatest])
            {
                greatest = i;
            }
            if(least == -1 || _playerWins[i] < _playerWins[least])
            {
                least = i;
            }
        }
        Console.WriteLine($"Greatest winrate: Player {greatest + 1} at {_playerWins[greatest]} out of {_games} games");
        Console.WriteLine($"Least winrate: Player {least + 1} at {_playerWins[least]} out of {_games} games");
    }

    public void Append(int[] wins, int games)
    {
        _playerWins = [.. _playerWins.Zip(wins, (a, b) => a + b)];
        _games += games;
    }
    public void Append(Report r)
    {
        if(this.GetDeck() != r.GetDeck())
        {
            throw new InvalidOperationException("incompatible reports: Deck type");
        }
        if(this.GetPlayerNumber() != r.GetPlayerNumber())
        {
            throw new InvalidOperationException("incompatible reports: player number");
        }
        _playerWins = [.. _playerWins.Zip(r.GetPlayerWins(), (a, b) => a + b)];
        _games += r.GetGames();

    }

    public int GetPlayerNumber()
    {
        return _players;
    }

    public Deck GetDeck()
    {
        return _deckUsed;
    }

    public int GetGames()
    {
        return _games;
    }

    public int[] GetPlayerWins()
    {
        return _playerWins;
    }

    /*
    Optional: Distrobution graph
    private void Graph(){

    }
    */
}