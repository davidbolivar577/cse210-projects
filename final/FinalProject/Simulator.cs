class Simulator
{
    private int _players;
    private Deck _deck;
    private int _games;
    private Report _results;
    
    public Simulator(int p, Deck d, int g)
    {
        _players = p;
        _deck = d;
        _games = g;
        _results = new(_deck, _players, 0);
    }
    public Simulator(Config c)
    {
        _players = c.GetPlayers();
        _deck = c.GetDeck();
        _games = c.GetGames();
        _results = new(_deck, _players, _games);
    }
    public Simulator(Report r)
    {
        _players = r.GetPlayerNumber();
        _deck = r.GetDeck();
        _games = r.GetGames();
        _results = r;
    }

    public void SetGames(int g)
    {
        _games = g;
    }

    public void Run()
    {
        War sim = new(_players, _deck);
        int[] wins = new int[_players];
        for(int i = 0; i < _games; i++)
        {
            sim.Run();
        }
        //TODO add wins
        _results.Append(sim.getWins(), _games);
    }

    public Report Export()
    {
        return _results;
    }
}