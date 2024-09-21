using _6LetterWords.Dal.Interfaces;

namespace _6LetterWords.Dal
{
    internal class FileDataLoader : IDataLoader
    {
        private readonly string _filePath;

        public FileDataLoader(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<IEnumerable<string>> LoadDataAsync()
        {
            if (!File.Exists(_filePath))
            {
                throw new FileNotFoundException($"No file exists at {_filePath}");
            }

            return await File.ReadAllLinesAsync(_filePath);
        }
    }
}