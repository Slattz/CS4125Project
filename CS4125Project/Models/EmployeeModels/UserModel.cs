using System.Diagnostics.Contracts;

namespace CS4125Project.Models.EmployeeModels
{
    public class UserModel
    {

        public string name { 

            get { 
                return name; 
            } 

            set { 
                Contract.Requires(value.Split(" ").Length > 1); 
            } 

        }

        public int id { 

            get { 
                return id;  
            } 
            
            set { 
                Contract.Requires(value > 0); 
            } 

        }

        public string email { 
            
            get { 
                return email; 
            }  
            
            set { 
                Contract.Requires(value.Contains("@") && value.Contains(".")); 
            } 

        }

    }
}
