namespace CsvVisualiser.Common.Interfaces
{
    public interface ICsvExtraction<T>
    {
        IEnumerable<T> GetData(Stream fileInput);
    }
}