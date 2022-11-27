using System;
using System.Collections.Generic;
using CS4125Project.Models.EmployeeModels;

namespace CS4125Project.Models.RotaModels
{
    public class RotaModel
    {
        public DateTime mondayDate;
        public List<ShiftModel> shifts;
        public List<EmployeeModel> employees;
    }
}