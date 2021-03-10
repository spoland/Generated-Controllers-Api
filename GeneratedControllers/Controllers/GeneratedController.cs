using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GeneratedControllers.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("generated")]
    public class GeneratedController<T, TId> : ControllerBase 
        where T : class
    {
        [HttpGet]
        public ActionResult<IEnumerable<T>> Get()
        {
            return BadRequest();
        }

        [HttpGet("{id}")]
        public ActionResult<T> Get(TId id)
        {
            return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult<T> Put(TId id)
        {
            return BadRequest();
        }

        [HttpPost("{id}")]
        public ActionResult Post(TId id, [FromBody] T value)
        {
            return BadRequest();
        }
    }
}
