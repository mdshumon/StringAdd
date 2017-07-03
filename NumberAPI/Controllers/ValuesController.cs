using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StringMathLib;

namespace NumberAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        private readonly StringNumber calc;
        public ValuesController(StringNumber num)
        {
            this.calc = num;
        }
        // GET api/values
        [HttpGet]

        public string AddNumbers(string numbers1, string numbers2)
        {
            if (string.IsNullOrEmpty(numbers1) || string.IsNullOrEmpty(numbers2))
                return null;
            return calc.AddOrSubNumber(numbers1, numbers2);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
