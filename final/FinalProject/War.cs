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
        List<Player> active = _players;
        //reset players
        foreach(Player p in active)
        {
            p.Reset(_deck);
        }

        //TODO remove
        Player winner = null;

        //run game of war, return player who won
        do
        {
            winner = Round(active);

            _playArea.RemoveAll(item => item == null);
            _discard.RemoveAll(item => item == null);

            winner.AddToDiscard(_playArea);
            winner.AddToDiscard(_discard);

            _playArea = [];
            _discard = [];

        }
        while (active.Count > 1);
        winner.Win();
    }

    private Player Round(List<Player> playing)
    {
        foreach (Player p in playing)
        {
            _playArea.Add(p.Play());
        }
        List<Player> winners = Greatest(playing);
        while (winners.Count > 1)
        {
            winners = WarRound(winners);
        }
        return winners[0];
    }

    private List<Player> WarRound(List<Player> playing)
    {
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
        for(int i = 0; i < wins.Length; i++)
        {
            wins[i] = _players[i].GetWins();
        }
        return wins;
    }




    //support functions
    private List<Player> Greatest(List<Player> playing)
    {
        Card.Value high = Enumerable.Max(_playArea).GetValue();
        List<Player> winners = [];
        for (int i = 0; i < _playArea.Count; i++)
        {
            if (high == _playArea[i].GetValue())
            {
                winners.Add(playing[i]);
            }
        }
        return winners;
    }
    private static List<Player> RemoveEmpty(List<Player> active)
    {
        for (int i = active.Count; i >= 0; i--)
        {
            if (active[i].GetRemaining() > 0)
            {
                active.RemoveAt(i);
            }
        }
        return active;
    }
}