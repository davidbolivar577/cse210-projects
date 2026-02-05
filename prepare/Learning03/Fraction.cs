public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int i)
    {
        _top = i;
        _bottom = 1;
    }
    public Fraction(int t, int b)
    {
        _top = t;
        _bottom = b;
    }

    public int GetTop()
    {
        return _top;
    }
    public void SetTop(int t)
    {
        _top = t;
    }
    public int GetBottom()
    {
        return _bottom;
    }
    public void SetBottom(int b)
    {
        _bottom = b;
    }

    public string GetFractionalString()
    {
        return $"{_top}/{_bottom}";
    }
    public double GetDecimalValue()
    {
        return (double)_top/(double)_bottom;
    }
}