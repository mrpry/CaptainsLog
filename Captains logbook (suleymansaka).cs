using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        WriteToJournal();
    }

    static void WriteToJournal()
    {
        var lines = new System.Collections.Generic.List<string>();
        bool writing = false;

        // Type start to enter data into the captain's logbook
        Console.WriteLine("Type 'start' to write an adventure in the captain's logbook");
        while (true)
        {
            string line = Console.ReadLine();
            if (line.ToLower() == "start")
            {
                writing = true;
                Console.WriteLine("Okay, the captain's logbook is listening to you. Don't forget to write 'stop' when you finish");
            }
            else if (line.ToLower() == "stop")
            {
                writing = false;
                break;
            }
            else if (writing)
            {
                lines.Add(line);
            }
        }

        // Write to file
        string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
        string filename = $"{currentDate}.txt";
        using (StreamWriter file = new StreamWriter(filename))
        {
            file.WriteLine("Captain’s logbook");
            file.WriteLine($"Stardate {currentDate}");
            foreach (string line in lines)
            {
                file.WriteLine(line);
            }
        }

        Console.WriteLine($"This amazing adventure was recorded in the notebook {filename}.");
    }
}
