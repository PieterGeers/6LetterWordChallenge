using _6LetterWords.Config;
using _6LetterWords.Dal.Interfaces;
using _6LetterWords.Services.Models;

namespace _6LetterWords.Services
{
    internal class WordProcessor
    {
        private readonly IDataReaderWriter<IEnumerable<string>> _dataReaderWriter;
        private readonly AppConfig _appConfig;

        public WordProcessor(IDataReaderWriter<IEnumerable<string>> dataReaderWriter, AppConfig appConfig)
        {
            _dataReaderWriter = dataReaderWriter;
            _appConfig = appConfig;
        }

        public async Task ProcessWordsAsync()
        {
            var data = (await _dataReaderWriter.ReadAsync(_appConfig.FileInputPath)).Distinct();

            var completeWords = data.Where(x => x.Length == _appConfig.WordLength).Select(x => new Word(x));
            HashSet<string> wordSections = new HashSet<string>(data.Where(x => x.Length < _appConfig.WordLength));

            List<string> combinations = new List<string>();
            foreach (var word in completeWords)
            {
                combinations.AddRange(word.GetAllPossibleCombination(wordSections));
            }

            await _dataReaderWriter.WriteAsync(_appConfig.FileOutputPath, combinations);
        }
    }
}
