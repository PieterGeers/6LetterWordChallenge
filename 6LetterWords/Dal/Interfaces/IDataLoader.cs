namespace _6LetterWords.Dal.Interfaces
{
    internal interface IDataLoader
    {
        Task<IEnumerable<string>> LoadDataAsync();
    }
}
