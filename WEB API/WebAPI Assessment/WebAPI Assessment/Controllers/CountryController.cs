using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_Assessment.Models;

namespace WebAPI_Assessment.Controllers
{
    public class CountryController : ApiController
    {
        private static List<Country> countries = new List<Country>
        {
            new Country { ID = 1, CountryName = "USA", Capital = "Washington, D.C." },
            new Country { ID = 2, CountryName = "India", Capital = "New Delhi" }
        };

        // GET api/country
        public IEnumerable<Country> Get()
        {
            return countries;
        }

        // GET api/country/{id}
        public IHttpActionResult Get(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country); 
        }

        // POST api/country
        public IHttpActionResult Post([FromBody] Country country)
        {
            if (country == null)
            {
                return BadRequest("Invalid data"); 
            }

            country.ID = countries.Max(c => c.ID) + 1;
            countries.Add(country);
            return CreatedAtRoute("DefaultApi", new { id = country.ID }, country); 
        }

        // PUT api/country/{id}
        public IHttpActionResult Put(int id, [FromBody] Country country)
        {
            var existingCountry = countries.FirstOrDefault(c => c.ID == id);
            if (existingCountry == null)
            {
                return NotFound();
            }

            existingCountry.CountryName = country.CountryName;
            existingCountry.Capital = country.Capital;
            return Ok(existingCountry);
        }

        // DELETE api/country/{id}
        public IHttpActionResult Delete(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
            {
                return NotFound(); 
            }

            countries.Remove(country);
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }
    }
}
