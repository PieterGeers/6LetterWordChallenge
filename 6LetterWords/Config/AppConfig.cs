namespace _6LetterWords.Config
{
    internal class AppConfig
    {
        public string FileInputPath { get; }
        public string FileOutputPath { get; }
        public int WordLength { get; }

        public AppConfig(string fileInputPath, string fileOutputPath, int wordLength)
        {
            FileInputPath = fileInputPath;
            FileOutputPath = fileOutputPath;
            WordLength = wordLength;
        }
    }
}
