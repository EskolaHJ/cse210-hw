using System;

public class Entry
{
    private string _entry;
    private string _prompt;
    public DateTime date { get; set; } = DateTime.Now;

    public Entry(DateTime date, string prompt, string answer)
    {
        this.date = date;
        this._prompt = prompt;
        this._entry = answer;
    }

    public DateTime GetDateTime()
    {
        return this.date;
    }

    public string GetPrompt()
    {
        return this._prompt;
    }

    public string GetEntry()
    {
        return this._entry;
    }
}
