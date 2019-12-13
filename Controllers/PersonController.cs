using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JsonMapping.Models;

namespace JsonMapping.Controllers
{
    public class PersonController : ApiController
    {
        public Person Get()
        {
            return new Person
            {
                Name = "Bob",
                Children = new List<Person>
                {
                    new Person
                    {
                        Name = "Tim",
                        FavouriteSport = new Squash { CourtName = "Romsey" }
                    },
                    new Person
                    {
                        Name = "Kate",
                        FavouriteSport = new Football { PitchName = "Winchester" }
                    }
                }
            };
        }

        public Person Post(Person person)
        {
            return person;
        }
    }
}
