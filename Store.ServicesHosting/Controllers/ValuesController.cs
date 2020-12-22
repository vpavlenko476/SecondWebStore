using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Store.ServicesHosting.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static readonly List<string> NumArray = Enumerable.Range(1, 10).Select(i => $"value {i}").ToList();

        [HttpGet]
        public List<string> Get() => NumArray;

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id < 0)
                return BadRequest();
            if (id > NumArray.Count())
                return NotFound();
            return NumArray[id];
        }

        [HttpPost]
        public void Post([FromBody] string value) => NumArray.Add(value);

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            if (id < 0)
                return BadRequest();
            if (id > NumArray.Count())
                return NotFound();
            NumArray[id] = value;
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0)
                return BadRequest();
            if (id > NumArray.Count())
                return NotFound();
            NumArray.RemoveAt(id);
            return Ok();
        }
    }
}