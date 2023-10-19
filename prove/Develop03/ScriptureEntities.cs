using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemory
{
    // The Scripture class is responsible for representing and handling Scripture-related operations.
    public class Scripture
    {
        private ScriptureReference _reference;
        private List<ScriptureWord> _words;
        public bool AllWordsHidden => _words.All(w => w.IsHidden);

        public Scripture(ScriptureReference reference, string text)
        {
            _reference = reference;
            _words = text.Split(' ').Select(word => new ScriptureWord(word)).ToList();
        }

        public void HideRandomWord()
        {
            var wordsToHide = _words.Where(w => !w.IsHidden).ToList();
            if (wordsToHide.Any())
            {
                var randomWord = wordsToHide[new Random().Next(wordsToHide.Count)];
                randomWord.Hide();
            }
        }

        public override string ToString()
        {
            return $"{_reference}\n\n{string.Join(' ', _words)}";
        }
    }

    // The ScriptureWord class represents individual words in a scripture and their hidden state.
    public class ScriptureWord
    {
        private string _text;
        private bool _isHidden;

        public bool IsHidden => _isHidden;

        public ScriptureWord(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public void Hide()
        {
            _isHidden = true;
        }

        public override string ToString()
        {
            return _isHidden ? "_____" : _text;
        }
    }

    // The ScriptureReference class represents and handles the reference of a scripture.
    public class ScriptureReference
    {
        private ScriptureVolume _volume;
        private string _book;
        private int _chapter;
        private int? _startVerse;
        private int? _endVerse;

        public ScriptureReference(ScriptureVolume volume, string book, int chapter, int startVerse)
        {
            _volume = volume;
            _book = book;
            _chapter = chapter;
            _startVerse = startVerse;
            _endVerse = null;
        }

        public ScriptureReference(ScriptureVolume volume, string book, int chapter, int startVerse, int endVerse) : this(volume, book, chapter, startVerse)
        {
            _endVerse = endVerse;
        }

        public override string ToString()
        {
            return _endVerse.HasValue ? $"{_volume} - {_book} {_chapter}:{_startVerse}-{_endVerse}" : $"{_volume} - {_book} {_chapter}:{_startVerse}";
        }
    }
}
