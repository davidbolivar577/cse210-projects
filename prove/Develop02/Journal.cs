public class Journal
{
    public List<Entry> entries;

    Journal()
    {
        entries = [];
    }
    Journal(List<Entry> existing)
    {
        entries = existing;
    }

    public static Journal Load(string filename)
    {
        Journal j = new();
        string[] lines = System.IO.File.ReadAllLines(filename);
        foreach(string line in lines){
            string currentLine = line.Substring(1,line.Length - 2);
            string[] nEntry = line.Split("\",\"");
            j.entries.Add(new Entry(nEntry));
        }
        return j;
    }

    public void Display()
    {
        if(entries.Count() == 0){
            Console.WriteLine("Journal is empty.");
        }
        else{
            foreach(Entry e in entries)
            {
                e.Display();
            }
        }
    }

    public void Save(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            if(entries.Count() == 0){
            Console.WriteLine("Action not available. Journal is empty.");
            }
            else{
                foreach(Entry e in entries)
                {
                    outputFile.WriteLine(e.Store());
                }
            }
            
        }
    }
}