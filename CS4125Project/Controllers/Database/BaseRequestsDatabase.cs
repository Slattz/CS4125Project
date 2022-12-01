using CS4125Project.Models.EmployeeModels;
using System.Collections.Generic;

namespace CS4125Project.Controllers.Database
{
    public class BaseRequestsDatabase<T> where T : WorkerRequestModel
    {
        protected IDatabase<T> db;

        protected BaseRequestsDatabase(string dbPath)
        {
            db = DatabaseFactory.GetDefaultDBController<T>(dbPath);
        }

        public void GetAllRequests(out List<T> requests)
        {
            db.Deserialize(out List<T> models);
            requests = models;
        }

        public void GetOpenRequests(List<T> requests)
        {
            requests.Clear();
            db.Deserialize(out List<T> models);
            foreach (var item in models)
            {
                if (!item.closed)
                {
                    requests.Add(item);
                }
            }
        }

        public T GetRequestByID(int requestID)
        {
            db.Deserialize(out List<T> models);
            foreach (var item in models)
            {
                if (item.requestID == requestID)
                {
                    return item;
                }
            }
            return null;
        }

        public int GetNextRequestID()
        {
            db.Deserialize(out List<T> models);
            return models.Count + 1;
        }

        protected bool RequestEquals(T model1, T model2)
        {
            return model1.requestID == model2.requestID;
        }

        public void UpdateRequest(T model, bool closed)
        {
            model.closed = closed;
            db.Update(model, RequestEquals);
        }

        
        public void InsertRequest(T model)
        {
            db.Insert(model);
        }

        public void Clear()
        {
            db.Clear();
        }
    }
}
