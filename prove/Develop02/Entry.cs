using System.ComponentModel.DataAnnotations;

public class Entry
{
    public string date;
    public string prompt;
    public string answer;

    public Entry(string p, string a)
    {
        date = DateTime.Now.ToLongDateString();
        prompt = p;
        answer = a;
    }
    public Entry(string[] e)
    {
        date = Desanitize(e[0]);
        prompt = Desanitize(e[1]);

        //optional: add separator handling by rejoining any index past 2
        answer = Desanitize(e[2]);
    }

    public void Display()
    {
        Console.WriteLine($"Date: {date}\nPrompt: {prompt}\n{answer}\n");
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
        foreach (char c in input)
        {
            output += c;
            if (c == '"')
            {
                output += '"';
            }
        }
        return output;
    }
    static string Desanitize(string input)
    {
        bool last = false;
        string output = "";

        foreach (char c in input)
        {
            if (last)
            {
                if (c != '"')
                {
                    output += c;
                }
                last = false;
            }
            else if (output.EndsWith('"'))
            {
                last = true;
                output += c;
            }
            else
            {
                output += c;
            }
        }
        return output;
    }
}