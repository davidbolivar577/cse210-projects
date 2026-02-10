public class Verse
{
    private string reference;
    private List<Word> words = [];

    public Verse(string verseIn)
    {
        List<string> wordList = new(verseIn.Split(' '));
        reference = wordList[0];
        for(int i = 1; i < wordList.Count; i++)
        {
            words.Add(new Word(wordList[i]));
        }
    }

    public int GetLength()
    {
        return words.Count;
    }

    public string Display()
    {
        string whole = reference;
        foreach(Word w in words)
        {
            whole += $" {w.Display()}";
        }
        return whole;
    }

    public void Hide(int h)
    {
        words[h].Hide();
    }
}