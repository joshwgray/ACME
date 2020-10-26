using System;

namespace ACME.Shared.Model
{
    public class PersonModel
    {
        public int PersonId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
