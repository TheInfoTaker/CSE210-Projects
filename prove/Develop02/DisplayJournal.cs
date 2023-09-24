using System;
using System.Collections.Generic;

class DisplayJounal
{
    private List<Entry> entries = new List<Entry>();

    public void DisplayEntries()
    {
        foreach (Entry entry in entries)
        {
            entry.Display();
        }
    }
}
