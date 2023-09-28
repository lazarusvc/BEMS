using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;

namespace Budget_Estimates_Management_System.CsvHandler
{
    public class CsvHandler
    {
        public List<T> CsvReader<T>(Stream file)
        {
            using (var reader = new StreamReader(file))

            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<T>().ToList();

                return records;
            }
        }

        public void CsvWriter<T>(List<T> csvList, string file)
        {
            string path = file;

            using (var writer = new StreamWriter(path))
            {
                using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords(csvList);
                }
            }
        }
    }

}
