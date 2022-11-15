namespace CS4125Project.Models.EmployeeModels
{
    public enum AuthLevel
    {
        Worker,
        Manager,
        GeneralManager
    }
    public class EmployeeModel : UserModel
    {
        public string role;
        public float sickDays;
        public float holidays;
        public AuthLevel level;
    }
}
