using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(string referenceText, string scriptureText)
    {
        _reference = ParseReference(referenceText);
        _words = ParseScriptureText(scriptureText);
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();

        for (int i = 0; i < numberToHide; i++)
        {
            int randomIndex = random.Next(_words.Count);
            _words[randomIndex].Hide();
        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + Environment.NewLine;

        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }

        return displayText;
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.Hidden())
            {
                return false;
            }
        }
        return true;
    }

    private Reference ParseReference(string referenceText)
    {
        //CHANGE
        return new Reference("John", 3, 16);
    }

    //INSPECT
    private List<Word> ParseScriptureText(string scriptureText)
    {
        string[] words = scriptureText.Split(new[] { ' ', '\t', '\n', '\r', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        List<Word> wordList = new List<Word>();

        foreach (string word in words)
        {
            wordList.Add(new Word(word));
        }

        return wordList;
    }
}
