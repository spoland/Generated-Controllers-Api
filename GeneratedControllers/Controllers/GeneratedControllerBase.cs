using GeneratedControllers.Contracts;
using GeneratedControllers.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GeneratedControllers.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("generated")]
    public class GeneratedControllerBase<T, TId> : ControllerBase 
        where T : class, IContract<TId>
    {
        private readonly Storage<T, TId> _storage;

        public GeneratedControllerBase(Storage<T, TId> storage)
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

        [HttpPut]
        public ActionResult<T> Put([FromBody] T value)
        {
            _storage.AddOrUpdate(value.Id, value);
            return Ok(value);
        }

        [HttpPost]
        public ActionResult<T> Post([FromBody] T value)
        {
            _storage.AddOrUpdate(value.Id, value);
            return CreatedAtAction("Get", value);
        }
    }
}
