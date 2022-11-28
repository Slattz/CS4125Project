﻿using CS4125Project.Models.RotaModels;
using CS4125Project.Models.EmployeeModels;
using System.Collections.Generic;
using System;

namespace CS4125Project.Controllers.EmployeeControllers
{
    public class EmployeeSelector
    {
        public Dictionary<int, EmployeeModel> getEmployeesToCover(List<ShiftModel> shifts, List<EmployeeModel> employees)
        {
            //alogrithm used to figure out who should cover a given shift
            Dictionary<int, EmployeeModel> shiftEmployeeMap = new Dictionary<int, EmployeeModel>();
            var random = new Random();
            foreach (ShiftModel shift in shifts)
            {
                shiftEmployeeMap.Add(shift.id, employees[random.Next(employees.Count)]);
            }
            return shiftEmployeeMap;
        }
    }
}