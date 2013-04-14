using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Controls.Examples.Models;

namespace MVC.Controls.Examples.Repositories
{
    public class PersonRepository
    {
        public List<Person> GetAllPersons()
        {
            List<Person> result = new List<Person>();
            List<City> cities = GetAllCities();
            const int max = 20;

            for (int i = 0; i < max; i++)
                result.Add(new Person() { PersonId = max - i, City = cities[(i * 4 + 1) % 15], FirstName = "Person " + i.ToString(), LastName = "Last Name" });

            //result.ForEach(person => person.CityId = person.City.Id);

            return result;
        }

        public List<City> GetAllCities()
        {
            List<City> result = new List<City>();

            for (int i = 0; i < 15; i++)
                result.Add(new City() { Id = Guid.NewGuid(), Name = "City " + i.ToString() });

            return result;
        }
    }
}
