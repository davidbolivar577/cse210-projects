using System.Text.Json.Serialization;

class Card
{
    public enum Suit
    {
        Heart, Diamond, Club, Spade
    }
    public enum Value
    {
        Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
    }

    [JsonInclude]
    private Suit _suit;
    [JsonInclude]
    private Value _value;

    public Card(Suit s, Value v)
    {
        _suit = s;
        _value = v;
    }

    [JsonConstructor]
    public Card()
    {
        
    }

    public override string ToString()
    {
        return $"{_value} of {_suit}s";
    }
    public Value GetValue()
    {
        return _value;
    }
    public Suit GetSuit()
    {
        return _suit;
    }

    public static bool operator ==(Card left, Card right)
    {
        if(left is null && right is null)
        {
            return true;
        }

        if(left is null ^ right is null)
        {
            return false;
        }
        if (left.GetValue() == right.GetValue())
        {
            return true;
        }
        return false;
    }
    public static bool operator !=(Card left, Card right)
    {
        return !(left == right);
    }
    public override bool Equals(object o)
    {
        if (o is Card card)
        {
            if (this.GetSuit() == card.GetSuit() && this.GetValue() == card.GetValue())
            {
                return true;
            }
        }
        return false;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(_suit, _value);
    }

    public static bool operator >(Card left, Card right)
    {
        if (left.GetValue() > right.GetValue())
        {
            return true;
        }
        return false;
    }
    public static bool operator <(Card left, Card right)
    {
        if (left.GetValue() < right.GetValue())
        {
            return true;
        }
        return false;
    }
}