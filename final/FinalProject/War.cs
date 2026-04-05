class War
{
    List<Player> _players;
    Deck _deck;
    List<Card> _playArea;
    List<Card> _discard;
    public War(int p, Deck d)
    {
        _players = [];
        _playArea = [];
        _discard = [];
        for (int i = 0; i < p; i++)
        {
            _players.Add(new());
        }
        _deck = d;
    }

    public void Run()
    {
        List<Player> active = [.. _players];
        //reset players
        foreach (Player p in active)
        {
            p.Reset(_deck);
        }

        Player winner = null;

        //run game of war, return player who won
        do
        {
            active = RemoveEmpty(active);
            winner = Round(active);

            _playArea.RemoveAll(item => item == null);
            _discard.RemoveAll(item => item == null);

            _discard.AddRange(_playArea);
            _playArea = [];
            if (winner is not null)
            {
                winner.AddToDiscard(_discard);
                _discard = [];
                active = RemoveEmpty(active);
            }
            //final draw safety
            else if (NoneRemaining(active))
            {
                _discard = [];
                foreach (Player p in active)
                {
                    p.Reset(_deck);
                }
            }
        }
        while (active.Count > 1);
        if (active.Count == 0)
        {
            Console.Error.WriteLine("Error: there is no winner");
        }
        else
        {
            active[0].Win();
        }
    }

    private Player Round(List<Player> playing)
    {
        playing = RemoveEmpty(playing);
        foreach (Player p in playing)
        {
            _playArea.Add(p.Play());
        }
        List<Player> winners = Greatest(playing);
        while (winners.Count > 1)
        {
            winners = WarRound(winners);
        }
        if (winners.Count == 0)
        {
            return null;
        }
        return winners[0];
    }

    private List<Player> WarRound(List<Player> playing)
    {
        playing = RemoveEmpty(playing);
        _playArea.RemoveAll(item => item == null);
        _discard.AddRange(_playArea);
        _playArea = [];
        //burn
        foreach (Player p in playing)
        {
            _discard.AddRange(p.Play(3, false));
        }
        //round
        foreach (Player p in playing)
        {
            _playArea.Add(p.Play());
        }
        return Greatest(playing);
    }


    public int[] getWins()
    {
        int[] wins = new int[_players.Count];
        for (int i = 0; i < wins.Length; i++)
        {
            wins[i] = _players[i].GetWins();
        }
        return wins;
    }




    private List<Player> Greatest(List<Player> playing)
    {
        Card.Value? high = null;
        List<Player> winners = [];
        for (int i = 0; i < _playArea.Count; i++)
        {
            if ((high is null && _playArea[i] is not null) || (_playArea[i] is not null && _playArea[i].GetValue() > high))
            {
                high = _playArea[i].GetValue();
            }
        }

        for (int i = 0; i < _playArea.Count; i++)
        {
            if (_playArea[i] is not null && _playArea[i].GetValue() == high)
            {
                winners.Add(playing[i]);
            }
        }
        return winners;
    }

    private static bool NoneRemaining(List<Player> players)
    {
        foreach (Player p in players)
        {
            if (p.GetRemaining() > 0)
            {
                return false;
            }
        }
        return true;
    }


    //support functions
    private static List<Player> RemoveEmpty(List<Player> active)
    {
        for (int i = active.Count - 1; i >= 0; i--)
        {
            if (active[i].GetRemaining() == 0)
            {
                active.RemoveAt(i);
            }
        }
        return active;
    }

}