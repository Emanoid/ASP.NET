using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAPI.Controllers

{   /// <summary>
    /// This is where i give you information about the API. This is an XML comment
    /// </summary>
    public class PeopleController : ApiController
    {
        List<Person> people = new List<Person>();

        public PeopleController() 
        {
            people.Add(new Person { FirstName = "Tim", Lastname = "Corey", Id = 1 });
            people.Add(new Person { FirstName = "Sue", Lastname = "Storm", Id = 2 });
            people.Add(new Person { FirstName = "Bilbo", Lastname = "Baggims", Id = 3 });
        }


        // GET api/<controller>
        public List<Person> Get()
        {
            return people;
        }

        // GET api/<controller>/5
        public Person Get(int id)
        {
            return people.Where(x => x.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Gets a list of the first names of all users
        /// </summary>
        /// <returns></returns>
        [Route("api/people/GetFirstNames")]
        [HttpGet]
        public List<string> GetFirstNames()
        {
            List<string> firstNames = new List<string>();
            people.ForEach(x => firstNames.Add(x.FirstName));
            return firstNames;
        }

        /// <summary>
        /// Gets the last name of a spefific user
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <returns>The lastname of the user</returns>
        [Route("api/people/GetLastName/{Id:int}")]
        [HttpGet]
        public string GetLastName(int id)
        {
            return people.Where(x => x.Id == id).FirstOrDefault().Lastname;
        }

        // POST api/<controller>
        public void Post(Person val)
        {
            people.Add(val);
        }

        ///
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            people.Remove(people.Where(x => x.Id == id).FirstOrDefault());
        }
    }
}