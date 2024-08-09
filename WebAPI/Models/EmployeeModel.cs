using WebAPI.Enums;

namespace WebAPI.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DepartmentEnum Department { get; set; }
        public bool Active { get; set; }
        public ShiftEnum Shift { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DateModified { get; set; } = DateTime.Now.ToLocalTime();
    }
}
