using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(50, ErrorMessage = "The Name field cannot be more than {1} characters long.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field must be a valid email address.")]
        public string Email { get; set; }
        [Range(1000000000, 9999999999, ErrorMessage = "The Phone field must be a valid 10-digit phone number.")]
        public long Phone { get; set; }
        public DateTime DateofBirth { get; set; }

        [Required(ErrorMessage = "The Department field is required.")]
        public string Department { get; set;}
    }
}
