// See https://aka.ms/new-console-template for more information

using _6LetterWords.Config;
using _6LetterWords.Dal;
using _6LetterWords.Dal.Interfaces;
using _6LetterWords.Services;

string inputFilePath = "C:\\Users\\pgeer\\Desktop\\KenzeChallenge\\input.txt";
string outputFilePath = "C:\\Users\\pgeer\\Desktop\\KenzeChallenge\\output.txt";
AppConfig config = new AppConfig(inputFilePath, outputFilePath, 6);

IDataReaderWriter<IEnumerable<string>> loader = new FileReaderWriter();

WordProcessor processor = new WordProcessor(loader, config);
await processor.ProcessWordsAsync();
