using CsvHelper.Configuration.Attributes;
using System.Diagnostics.Contracts;

namespace CS4125Project.Models.EmployeeModels
{
    public class UserModel
    {
        [Index(0), Name("name")]

        internal string name { get; set; }

        [Index(1), Name("id")]
        internal int id { get; set; }

        [Index(2), Name("email")]
        internal string email { get; set; }

        public string GetEmail()
        {
            return email;
        }

        public void SetEmail(string value)
        {
            Contract.Requires(value.Contains("@") && value.Contains("."));
            email = value;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string value)
        {
            Contract.Requires(value.Split(" ").Length > 1);
            name = value;
        }

        public int GetID()
        {
            return id;
        }

        public void SetID(int value)
        {
            Contract.Requires(value > 0);
            id = value;
        }


    }
}
