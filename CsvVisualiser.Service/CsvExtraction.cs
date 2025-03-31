using CsvHelper;
using CsvHelper.Configuration;
using CsvVisualiser.Common.Interfaces;
using System.Globalization;
using System.Text;

namespace CsvVisualiser.Service
{
    public class CsvExtraction<T> : ICsvExtraction<T>
    {
        public IEnumerable<T> GetData(Stream fileInput)
        {
            using (var reader = new StreamReader(fileInput, Encoding.Latin1))
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    PrepareHeaderForMatch = args => args.Header.Replace(" ", "")
                };

                using (var csvReader = new CsvReader(reader, config))
                {
                    return csvReader.GetRecords<T>().ToList();
                }
            }
        }
    }
}