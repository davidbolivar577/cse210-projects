using System.Text.Json.Serialization;

class Deck
{
    [JsonInclude]
    List<Card> _deck;

    public Deck()
    {
        _deck = GetDefault();
    }
    public Deck(List<Card> cards)
    {
        if (cards.Count == 0)
        {
            _deck = GetDefault();
        }
        else
        {
            _deck = cards;
        }
    }
    private static List<Card> GetDefault()
    {
        List<Card> deck = [];
        foreach (Card.Suit s in Enum.GetValues<Card.Suit>())
        {
            foreach (Card.Value v in Enum.GetValues<Card.Value>())
            {
                deck.Add(new(s, v));
            }
        }
        return deck;
    }
    public List<Card> GetDeck()
    {
        return _deck;
    }

    public void Shuffle()
    {
        Random r = new();
        for (int i = _deck.Count - 1; i > 0; i--)
        {
            int n = r.Next(i + 1);
            (_deck[n], _deck[i]) = (_deck[i], _deck[n]);
        }
    }

    public override bool Equals(Object o)
    {
        if (o is null || o is not Deck d)
        {
            return false;
        }
        List<Card> sorted = [.. _deck];
        List<Card> compare = [.. d.GetDeck()];
        if (sorted.Count != compare.Count)
        {
            return false;
        }
        else
        {
            sorted.Sort();
            compare.Sort();
            for (int i = 0; i < sorted.Count; i++)
            {
                if (sorted[i] != compare[i])
                {
                    return false;
                }
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_deck);
    }

    public void Reset()
    {
        _deck = [];
    }
    public void Reset(Deck deck)
    {
        _deck = [.. deck.GetDeck()];
    }

    public Card Play()
    {
        if (_deck.Count == 0)
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
        for (int i = 0; i < n; i++)
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

