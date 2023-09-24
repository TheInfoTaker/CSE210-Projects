using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

public class Journal
{
    private List<Entry> entries = new List<Entry>();
    public void AddEntry(string prompt, string response)
    {
        entries.Add(new Entry(prompt, response));
    }

    public void DisplayEntries()
    {
        Console.WriteLine("\nJounal Entries:\n");
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date}: {entry.Prompt}");
                writer.WriteLine($"Response: {entry.Response}\n");
            }
        }
        Console.WriteLine($"Journal saved to{fileName}");
    }
    public void LoadFromFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            entries.Clear();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                string currentPrompt = "";
                string currentResponse = "";
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("Response: "))
                    {
                        entries.Add(new Entry(currentPrompt, currentResponse));
                        currentPrompt = "";
                        currentResponse = "";
                    }
                    else if (line.Contains(";"))
                    {
                        currentPrompt = line.Split(':')[1].Trim();
                    }
                    else if (line.StartsWith("Response: "))
                    {
                        currentResponse = line.Substring("Response ".Length).Trim();
                    }
                }

            }
            Console.WriteLine($"Journal loaded from {fileName}");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}