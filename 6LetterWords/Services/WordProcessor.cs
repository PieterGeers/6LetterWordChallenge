using _6LetterWords.Dal.Interfaces;
using _6LetterWords.Services.Models;

namespace _6LetterWords.Services
{
    internal class WordProcessor
    {
        private readonly IDataLoader _dataLoader;

        public WordProcessor(IDataLoader dataLoader)
        {
            _dataLoader = dataLoader;
        }

        public async Task ProcessWordsAsync()
        {
            var data = (await _dataLoader.LoadDataAsync()).Distinct();

            var completeWords = data.Where(x => x.Length == 6).Select(x => new Word(x));
            var wordSections = data.Where(x => x.Length != 6);

            int sum = 0;
            foreach (var word in completeWords)
            {
                var results = word.GetAllPossibleCombination(wordSections);

                sum += results.Count;
            }
            Console.WriteLine(sum);
        }
    }
}
