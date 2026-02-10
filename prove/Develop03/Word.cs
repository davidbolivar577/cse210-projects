public class Word
{
    private string word;
    private bool hidden = false;

    public Word(string wordIn)
    {
        word = wordIn;
    }

    public void Hide()
    {
        hidden = true;
    }

    public string Display()
    {
        if (hidden)
        {
            return new string('_', word.Length);
        }
        return word;
    }
}