public class Word
{
    private string _text;
    private bool _isHidden;

    public string Text => _text;

    public Word(string text)
    {
        _text = text;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden && _text.Length > 0)
        {
            string text;
            char s = _text[_text.Length - 1];
            if (s == '.' || s == ',' || s == '?' || s == '|')
            {
                text = new string('_', _text.Length - 1);
                return text + s;
            }
            else
            {
                text = new string('_', _text.Length);
            }
        }
        else
        {
            return _text;
        }
        return _isHidden ? new string('_', _text.Length) : _text;
    }

     
}
