using PeopleSearch.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.ViewModels
{
    public class SearchViewModel
    {
        public IEnumerable<Person> People { get; set; }
    }
}
