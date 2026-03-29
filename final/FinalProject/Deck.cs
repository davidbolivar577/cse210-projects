class Deck
{
    List<Card> _deck;

    public Deck()
    {
        _deck = [];
        foreach (Card.Suit s in Enum.GetValues<Card.Suit>())
        {
            foreach (Card.Value v in Enum.GetValues<Card.Value>())
            {
                _deck.Add(new(s, v));
            }
        }
    }
    public Deck(List<Card> cards)
    {
        _deck = cards;
    }
    public List<Card> GetDeck()
    {
    	return _deck;
    }

    public void Shuffle()
    {
        Random r = new();
        for(int i = _deck.Count - 1; i > 0; i--)
        {
            int n = r.Next(i+1);
            (_deck[n], _deck[i]) = (_deck[i], _deck[n]);
        }
    }

    public void Reset()
    {
        _deck = [];
    }
    public void Reset(Deck deck)
    {
        _deck = deck.GetDeck();
    }
    
    public Card Play()
    {
        if(_deck.Count == 0)
        {
            return null;
        }
        Card c = _deck[0];
        _deck.RemoveAt(0);
        return c;
    }
    public List<Card> Play(int n)
    {
        List<Card> extra = [];
        for(int i = 0; i < n; i++)
        {
            extra.Add(Play());
        }
        return extra;
    }

    public void Add(Card c)
    {
        _deck.Add(c);
    }
    public void Add(List<Card> cards)
    {
        _deck.AddRange(cards);
    }


    public int GetRemaining()
    {
        return _deck.Count;
    }
}

