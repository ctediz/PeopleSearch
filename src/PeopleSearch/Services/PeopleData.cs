using PeopleSearch.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Services
{
    public interface IPeopleData
    {
        IEnumerable<Person> GetAll();
        Person Get(int id);
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

        public IEnumerable<Person> GetAll()
        {
            return _context.People;
        }
    }
}
