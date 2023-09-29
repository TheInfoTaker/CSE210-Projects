using System;

public class Word
{
    private string _text;
    private bool _Hidden;

    public Word(string text)
    {
        _text = text;
        _Hidden = false;
    }

    public void Hide()
    {
        _Hidden = true;
    }

    public void Show()
    {
        _Hidden = false;
    }

    public bool Hidden()
    {
        return _Hidden;
    }

    public string GetDisplayText()
    {
        return _Hidden ? new string('_', _text.Length) : _text;
    }
}
