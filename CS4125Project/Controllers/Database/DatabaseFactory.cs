using CsvHelper.Configuration;

namespace CS4125Project.Controllers.Database
{
    public class DatabaseFactory
    {
        public static IDatabase<T> GetDefaultDBController<T>(string path)
        {
            switch (Properties.Resources.DatabaseEngine.ToUpper())
            {
                case "CSV":
                    return new CSVDatabase<T>(path);
                default:
                    return null;
            }
        }
    }
}
