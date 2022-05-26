using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApi.Data.Entities
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }

        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime TimeStartWork { get; set; }
    }
}
