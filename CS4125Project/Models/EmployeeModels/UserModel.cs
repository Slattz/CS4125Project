using System;
using System.Diagnostics.Contracts;
using System.Net.Mail;

namespace CS4125Project.Models.EmployeeModels
{
    public class UserModel
    {

        internal string name;

        internal int id;

        internal string email;

        public string GetEmail()
        {
            return email;
        }

        public void SetEmail(string value)
        {
            Contract.Requires(IsValidEmail(value));
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

        private bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
