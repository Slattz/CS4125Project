using CS4125Project.Controllers.EmployeeControllers;
using CS4125Project.Models.EmployeeModels;
using System.Collections.Generic;

namespace CS4125Project.Controllers.Database
{
    public class EmployeeDatabase
    {
        private IDatabase<EmployeeModel> db;
        private static EmployeeDatabase instance = null;

        private EmployeeDatabase()
        {
            db = DatabaseFactory.GetDefaultDBController<EmployeeModel>("Employees");
        }

        public static EmployeeDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmployeeDatabase();
                }
                return instance;
            }
        }

        public void GetAllEmployees(out List<EmployeeModel> models)
        {
            db.Deserialize(out models);
        }
        public void InsertEmployee(EmployeeModel model)
        {
            db.Insert(model);
        }

        private bool EmployeeEquals(EmployeeModel model1, EmployeeModel model2)
        {
            return model1.id == model2.id;
        }

        public void UpdateEmployee(EmployeeModel model)
        {
            db.Update(model, EmployeeEquals);
        }

        public void Clear()
        {
            db.Clear();
        }

        public static List<EmployeeControllerBase> ModelsToEmployee(List<EmployeeModel> employees)
        {
            List<EmployeeControllerBase> emps = new List<EmployeeControllerBase>();
            foreach (EmployeeModel employee in employees)
            {
                emps.Add(new EmployeeControllerBase(employee));
            }
            return emps;
        }
    }
}
