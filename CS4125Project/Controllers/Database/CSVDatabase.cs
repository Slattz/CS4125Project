using CS4125Project.Models.EmployeeModels;
using CS4125Project.Models;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CS4125Project.Controllers.EmployeeControllers;
using CsvHelper.Configuration;
using System;

namespace CS4125Project.Controllers.Database
{
    public class CSVDatabase<T> : IDatabase<T>
    {
        protected string path;
        public CSVDatabase(string CSVPath)
        {
            path = Properties.Resources.CSVBaseDir + CSVPath + ".csv";
            if (!DBExists())
            {
                Create();
            }
        }

        public void Create()
        {
            FileStream fs = File.Create(path);
            fs.Close();
        }

        public void Delete(T model)
        {
            Console.WriteLine($"CSVDatabase: Deleted {model} from Database.");
        }

        public void Deserialize(out List<T> models)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                models = csv.GetRecords<T>().ToList();
            }
        }

        public bool DBExists()
        {
            return File.Exists(path);
        }

        public bool Exists(T model)
        {
            Deserialize(out List<T> records);
            foreach (var item in records)
            {
                if (model.GetHashCode() == item.GetHashCode())
                {
                    return true;
                }
            }

            return false;
        }

        public void Insert(T model)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using (var stream = File.Open(path, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecord(model);
            }
        }

        public void Update(T model, Func<T, T, bool> whereFunc)
        {
            Deserialize(out List<T> records);
            for (int i = 0; i < records.Count; i++)
            {
                if (whereFunc(records[i], model))
                {
                    records[i] = model;
                }
            }

            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }
        }

        public void Clear()
        {
            Create();
        }
    }
}
