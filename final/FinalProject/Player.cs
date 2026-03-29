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
        return _deck.Play();
    }
    public List<Card> Play(int n, bool playLastCard = true)
    {
        List<Card> played = [];
        while (_deck.GetRemaining() > 1 || playLastCard)
        {
            played.Add(_deck.Play());
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