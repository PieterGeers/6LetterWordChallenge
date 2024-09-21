// See https://aka.ms/new-console-template for more information

using _6LetterWords.Dal;
using _6LetterWords.Dal.Interfaces;
using _6LetterWords.Services;

string filePath = "C:\\Users\\pgeer\\Desktop\\KenzeChallenge\\input.txt";

IDataLoader loader = new FileDataLoader(filePath);

WordProcessor processor = new WordProcessor(loader);
await processor.ProcessWordsAsync();
