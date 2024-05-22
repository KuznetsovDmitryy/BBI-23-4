using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст:");
            string input = Console.ReadLine();

            SentenceAnalyz analyzer = new SentenceAnalyz(input);
            string longestSentence = analyzer.GetSentenceWithMostWords();

            Console.WriteLine("Предложение с наибольшим кол-вом слов:");
            Console.WriteLine(longestSentence);
            UniqueWordCounter wordCounter = new UniqueWordCounter(input);
            int countUniqueWords = wordCounter.CountUniqueWords();

            Console.WriteLine("Количество уникальных слов: " + countUniqueWords);
        }
    }
    class UniqueWordCounter
    {
        private string input;

        public UniqueWordCounter(string input)
        {
            this.input = input;
        }

        public int CountUniqueWords()
        {
            string[] words = input.Split(new char[] { ' ', ',', '.', ';', ':', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
            HashSet<string> uniqueWords = new HashSet<string>(words);

            return uniqueWords.Count;
        }
    }

    public class SentenceAnalyz
    {
        private string text;

        public SentenceAnalyz(string text)
        {
            this.text = text;
        }

        public string GetSentenceWithMostWords()
        {
            string[] sentences = SplitIntoSentences(text);
            string longestSentence = sentences.OrderByDescending(sentence => CountWords(sentence)).FirstOrDefault();
            return longestSentence ?? string.Empty;
        }

        private string[] SplitIntoSentences(string text)
        {
            char[] sentenceEndings = { '.', '!', '?' };
            return text.Split(sentenceEndings, StringSplitOptions.RemoveEmptyEntries);
        }

        private int CountWords(string sentence)
        {
            char[] delimiters = { ' ', '\t', '\n', '\r' };
            return sentence.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    public class UniqueWordCounter
        {
           private string input;

            public UniqueWordCounter(string input)
            {
                this.input = input;
            }

            public int CountUniqueWords()
            {
                string[] words = input.Split(new char[] { ' ', ',', '.', ';', ':', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
                HashSet<string> uniqueWords = new HashSet<string>(words);

                return uniqueWords.Count;
            }
        }
    }
}
