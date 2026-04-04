using Microsoft.VisualBasic;

class Player
{
    private Deck _deck;
    private List<Card> _discard;
    private int _wins;

    public Player(int wins = 0)
    {
        _deck = new();
        _discard = [];
        _wins = wins;
    }
    public Player(Deck deck, int wins = 0)
    {
        _deck = deck;
        _discard = [];
        _wins = wins;
    }

    public Card Play()
    {
        Card played = _deck.Play();
        if(played is null)
        {
            _deck.Add(_discard);
            _discard = [];
            _deck.Shuffle();
            played = _deck.Play();
        }
        return played;
    }
    public List<Card> Play(int n, bool playLastCard = true)
    {
        List<Card> played = [];
        for(int i = 0; i < n; i++)
        {
            if(GetRemaining() > 0 + (playLastCard ? 0 : 1))
            {
                played.Add(Play());
            }
        }
        return played;
    }

    public void AddToDiscard(Card c)
    {
        _discard.Add(c);
    }
    public void AddToDiscard(List<Card> cards)
    {
        _discard.AddRange(cards);
    }

    public void Reset(Deck d)
    {
        _deck.Reset(d);
        _deck.Shuffle();
        _discard = [];
    }

    public void Win()
    {
        _wins++;
    }
    public int GetWins()
    {
        return _wins;
    }

    public int GetRemaining()
    {
        return _deck.GetRemaining() + _discard.Count();
    }

}