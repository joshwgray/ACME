using System;

namespace ACME.Entities.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int PersonId { get; set; }
        public string EmployeeNum { get; set; }
        public DateTime EmployedDate { get; set; }
        public DateTime? TerminatedDate { get; set; }
    }
}
