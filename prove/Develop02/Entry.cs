using System.ComponentModel.DataAnnotations;

public class Entry
{
    public string date;
    public string prompt;
    public string answer;

    Entry(string p, string a)
    {
        date = DateTime.Now.ToLongDateString();
        prompt = p;
        answer = a;
    }
    Entry(string d, string p, string a)
    {
        date = d;
        prompt = p;
        answer = a;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {date}\nPrompt: {prompt}\n{answer}");
    }

    public string Store()
    {
        string stored = "";
        stored += $"\"{date}\"";
        stored += ",";
        stored += $"\"{prompt}\"";
        stored += ",";
        stored += $"\"{Sanitize(answer)}\"";
        return stored;
    }


    static string Sanitize(string input)
    {
        string output = "";
        foreach(char c in input)
        {
            output += c;
            if(c == '"')
            {
                output += '"';
            }
        }
        return output;
    }
}