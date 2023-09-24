using System;
using System.Collections.Generic;

public class DisplayJounal
{
    private List<Entry> entries = new List<Entry>();

public void AddEntry(Entry entry)
{
    entries.Add(entry);
}
    public void DisplayEntries()
    {
        foreach (Entry entry in entries)
        {
            entry.Display();
        }
    }
}
