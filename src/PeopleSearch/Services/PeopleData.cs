using PeopleSearch.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PeopleSearch.Services
{
    public interface IPeopleData
    {
        IEnumerable<Person> GetAll();
        Person Get(int id);
        IEnumerable<Person> Get(string nameFragment);
        Person Add(Person newPerson);
        void Commit();
    }

    public class SqlPersonData : IPeopleData
    {
        private PeopleSearchDbContext _context;

        public SqlPersonData(PeopleSearchDbContext context)
        {
            _context = context;
        }

        public Person Add(Person newPerson)
        {
            _context.Add(newPerson);

            return newPerson;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public Person Get(int id)
        {
            return _context.People.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Person> Get(string nameFragment)
        {
            return _context.People.Where(r => 
                (r.FirstName + r.LastName).Contains(nameFragment));
        }

        public IEnumerable<Person> GetAll()
        {
            return _context.People;
        }
    }
}
