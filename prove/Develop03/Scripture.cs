using System.ComponentModel.DataAnnotations;
using System.Reflection;

public class Scripture
{
    private string reference;
    private List<Verse> verses = [];
    private int length;
    private List<int> hidden = [];
    private int difficulty = 3;
    private Random rand = new();
    public Scripture(string referenceIn, string scriptureIn)
    {
        length = 0;

        reference = referenceIn;
        List<string> verseList = new(scriptureIn.Split('|'));
        foreach (string v in verseList)
        {
            Verse newVerse = new(v);
            verses.Add(newVerse);
            length += newVerse.GetLength();
        }


    }

    public string Display()
    {
        string whole = reference;
        foreach (Verse v in verses)
        {
            whole += $"\n{v.Display()}";
        }
        return whole;
    }

    public void HideBatch()
    {
        int hideNext = -1;
        for (int i = 0; i < difficulty; i++)
        {
            do
            {
                if(hidden.Count >= length)
                {
                    break;
                }
                hideNext = rand.Next(length);
            }
            while (hidden.Contains(hideNext));
            Hide(hideNext);
            hidden.Add(hideNext);
        }
    }
    private void Hide(int h)
    {
        int verseIndex = 0;
        if(h == -1)
        {
            return;
        }
        do
        {
            if(h >= verses[verseIndex].GetLength())
            {
                h -= verses[verseIndex].GetLength();
                verseIndex++;
            }
            else
            {
                verses[verseIndex].Hide(h);
                h = -1;
            }
        }while(h >= 0);
    }

    public bool AllHidden()
    {
        return hidden.Count >= length;
    }
}