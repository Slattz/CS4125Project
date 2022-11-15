﻿using System;

namespace CS4125Project.Models.RotaModels
{
    public enum Day
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    public class ShiftModel
    {
        public string requiredRole;
        public Day workday;
        public DateTime startTime;
        public DateTime endTime;
        public int id;
        public int employeeID;
    }
}
