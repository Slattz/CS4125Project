using CS4125Project.Controllers.EmployeeControllers;
using CS4125Project.Models.EmployeeModels;
using Microsoft.AspNetCore.SignalR.Protocol;
using System.Collections.Generic;
using System.Reflection;

namespace CS4125Project.Controllers.Database
{
    public class SickRequestsDatabase
    {
        private IDatabase<SickDayRequestModel> db;
        private static SickRequestsDatabase instance = null;

        private SickRequestsDatabase()
        {
            db = DatabaseFactory.GetDefaultDBController<SickDayRequestModel>("SickRequests");
        }

        public static SickRequestsDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SickRequestsDatabase();
                }
                return instance;
            }
        }

        public void GetAllSickRequests(out List<SickDayRequestModel> requests)
        {
            db.Deserialize(out List<SickDayRequestModel> models);
            requests = models;
        }

        public void GetOpenSickRequests(List<SickDayRequestModel> requests)
        {
            requests.Clear();
            db.Deserialize(out List<SickDayRequestModel> models);
            foreach (var item in models)
            {
                if (!item.closed)
                {
                    requests.Add(item);
                }
            }
        }

        public SickDayRequestModel GetSickRequestByID(int requestID)
        {
            db.Deserialize(out List<SickDayRequestModel> models);
            foreach (var item in models)
            {
                if (item.requestID == requestID)
                {
                    return item;
                }
            }
            return null;
        }

        public int GetNextSickRequestID()
        {
            db.Deserialize(out List<SickDayRequestModel> models);
            return models.Count + 1;
        }

        private bool RequestEquals(SickDayRequestModel model1, SickDayRequestModel model2)
        {
            return model1.requestID == model2.requestID;
        }

        public void UpdateRequest(SickDayRequestModel model, bool closed)
        {
            model.closed = closed;
            db.Update(model, RequestEquals);
        }

        
        public void InsertRequest(SickDayRequestModel model)
        {
            db.Insert(model);
        }

        public void Clear()
        {
            db.Clear();
        }
    }
}
