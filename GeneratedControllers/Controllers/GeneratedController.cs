using GeneratedControllers.Contracts;
using GeneratedControllers.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GeneratedControllers.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("generated")]
    public class GeneratedController<T, TId> : ControllerBase 
        where T : class, IContract<TId>
    {
        private readonly Storage<T, TId> _storage;

        public GeneratedController(Storage<T, TId> storage)
        {
            _storage = storage;
        }

        [HttpGet]
        public ActionResult<IEnumerable<T>> Get()
        {
            return Ok(_storage.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<T> Get(TId id)
        {
            return Ok(_storage.GetById(id));
        }

        [HttpPut("{id}")]
        public ActionResult<T> Put(TId id)
        {
            return BadRequest();
        }

        [HttpPost]
        public ActionResult<T> Post([FromBody] T value)
        {
            _storage.AddOrUpdate(value.Id, value);
            return CreatedAtAction("Get", value);
        }
    }
}
