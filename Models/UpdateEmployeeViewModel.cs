namespace EmployeeManagementSystem.Models
{
    public class UpdateEmployeeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Department { get; set; }
    }
}
