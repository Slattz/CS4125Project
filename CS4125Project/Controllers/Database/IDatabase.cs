using CsvHelper.Configuration;
using System;
using System.Collections.Generic;

namespace CS4125Project.Controllers.Database
{
    public interface IDatabase<T>
    {
        public void Create();
        public void Clear();
        public bool DBExists();
        public void Deserialize(out List<T> models);

        public void Insert(T model);
        public void Update(T model, Func<T,T, bool> whereFunc);
        public void Delete(T model);
        public bool Exists(T model);

    }
}
