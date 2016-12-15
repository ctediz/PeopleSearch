using System;

namespace PeopleSearch.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birth { get; set; }
        public string Interests { get; set; }
        // Picture?
    }
}