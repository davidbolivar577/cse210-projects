using System.Diagnostics.Contracts;

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

    private Suit _suit;
    private Value _value;

    public Card(Suit s, Value v)
    {
        _suit = s;
        _value = v;
    }

    public string GetName()
    {
        return $"{_value} of {_suit}s";
    }
    public Value GetValue()
    {
        return _value;
    }

    // public static bool operator ==(Card left, Card right)
    // {
    //     if (left.GetValue() == right.GetValue())
    //     {
    //         return true;
    //     }
    //     return false;
    // }
    // public static bool operator !=(Card left, Card right)
    // {
    //     if (left.GetValue() != right.GetValue())
    //     {
    //         return true;
    //     }
    //     return false;
    // }

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