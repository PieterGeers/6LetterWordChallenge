namespace _6LetterWords.Dal.Interfaces
{
    internal interface IDataReaderWriter<T>
    {
        Task<T> ReadAsync(string source);
        Task WriteAsync(string destination, T data);
    }
}
