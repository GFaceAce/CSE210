using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class Word
{
    private string _text;
    private bool _isHidden;
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }
    public void Hide()
    {
        _isHidden = true;
    }
    public void Show()
    {
        _isHidden = false;
    }
    public bool IsHidden()
    {
        return _isHidden;
    }
    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }
        string hiddenText = "";
        foreach (char c in _text)
        {
            if (char.IsLetter(c))
            {
                hiddenText += "_";
            }
            else
            {
                hiddenText += c;
            }
        }
        return hiddenText;
    }
}
public class Reference
{
    private string _book;
    private int _startChapter;
    private int _startVerse;
    private int _endChapter;
    private int _endVerse;
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _startChapter = chapter;
        _startVerse = verse;
        _endChapter = chapter;
        _endVerse = verse;
    }
    public Reference(string book, int startChapter, int startVerse, int endChapter, int endVerse)
    {
        _book = book;
        _startChapter = startChapter;
        _startVerse = startVerse;
        _endChapter = endChapter;
        _endVerse = endVerse;
    }
    public string GetDisplayText()
    {
        if (_startChapter == _endChapter && _startVerse == _endVerse)
        {
            return $"{_book} {_startChapter}:{_startVerse}";
        }
        return $"{_book} {_startChapter}:{_startVerse}-{_endVerse}";
    }
}
public class Scripture
{
    private Random random = new Random();
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        string[] splitWords = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in splitWords)
        {
            _words.Add(new Word(word));
        }
    }
    public void Display()
    {
        Console.WriteLine(GetRenderedText());

    }
    public string GetRenderedText()
    {
        List<string> renderedWords = new List<string>();
        foreach (Word word in _words)
        {
            renderedWords.Add(word.GetDisplayText());
        }
        return $"{_reference.GetDisplayText()} {string.Join(" ",renderedWords)}";
    }
    public void HideRandomWords(int count, Random random)
    {
        List<Word> visibleWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }
        int wordsToHide = Math.Min(count, visibleWords.Count);
        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }
    public bool AreAllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        program.Run();
    }
    private Random _random = new Random();
    public void Run()
    {
        List<Scripture> scriptures = BuildScriptures();
        Random random = new Random();
        Scripture selectedScripture = scriptures[random.Next(scriptures.Count)];
        while (true)
        {
            ClearScreen();
            selectedScripture.Display();
            string input = PromptUser();
            if (ShouldQuit(input))
            {
                break;
            }
            if (selectedScripture.AreAllWordsHidden())
            {
                break;
            }
            selectedScripture.HideRandomWords(3, _random);
        }
    }
    public void ClearScreen()
    {
        Console.Clear();
    }
    public string PromptUser()
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue or type 'quit': ");
        return Console.ReadLine();
    }
    public bool ShouldQuit(string input)
    {
        return input.ToLower() == "quit";
    }
    private List<Scripture> BuildScriptures()
    {
        List<Scripture> scriptures = new List<Scripture>();
        scriptures.Add(
            new Scripture(
                new Reference("John", 15,16),
                "Ye have not chosen me, but I have chosen you, and ordained you, that ye should go and bring forth fruit, and that your fruit should remain: that whatsoever ye shall ask of the Father in my name, he may give it you."
            )
        );
        scriptures.Add(
            new Scripture(
                new Reference("John", 3,16),
                "For God so loved the world, that he gave his only begotten Son, that whosever believeth in him should not perish, but have everlasting life."
            )
        );
        scriptures.Add(
            new Scripture(
                new Reference("Proverbs", 3, 5, 3, 6),
                "Trust in the LORD with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
            )
        );
        return scriptures;
    }
}