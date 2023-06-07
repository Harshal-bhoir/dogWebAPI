using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebAPI.Helper;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class DogController : ControllerBase
    {
        HelperFuncs ob = new HelperFuncs();

        // GET: api/Dogs
        [HttpGet]
        public List<Dog> Get()
        {
            var existText = ob.deserealizeRead();

            return existText;
        }

        // GET: api/Dogs/5
        [HttpGet("{id}", Name = "Get")]
        public Dog Get(int id)
        {
            var existText = ob.deserealizeRead();

            var ans = existText?.Find(dog => dog.Id == id);
            if (ans == null) return null;

            return ans;
        }

        [HttpPost]
        public void Post([FromBody] Dog value)
        {
            var existText = ob.deserealizeRead();

            existText?.Add(value);

            ob.serializeWrite(existText);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UpdateDog value)
        {
            var existText = ob.deserealizeRead();

            if (existText.Count < 1) return;

            var findDog = existText?.Find(dog => dog.Id == id);
            if (findDog == null) return;
            existText?.Remove(findDog);
            existText?.Add(new Dog() { Id = id, Age = value.Age, Name = value.Name });

            ob.serializeWrite(existText);
        }

        // DELETE: api/Dogs/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var existText = ob.deserealizeRead();

            if (existText.Count < 1) return;

            var found = existText?.Find(x => x.Id == id);
            if (found != null) existText?.Remove(found);

            ob.serializeWrite(existText);
        }
    }
}
