using _6LetterWords.Dal.Interfaces;

namespace _6LetterWords.Dal
{
    internal class FileReaderWriter : IDataReaderWriter<IEnumerable<string>>
    {
        public FileReaderWriter()
        { }

        public async Task<IEnumerable<string>> ReadAsync(string source)
        {
            if (!File.Exists(source))
            {
                throw new FileNotFoundException($"No file exists at {source}");
            }

            return await File.ReadAllLinesAsync(source);
        }

        public async Task WriteAsync(string destination, IEnumerable<string> data)
        {
            await File.WriteAllLinesAsync(destination, data);
        }
    }
}