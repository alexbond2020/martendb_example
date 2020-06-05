using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoApi.Models;
using TodoApi.Service;

namespace TodoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _service;
        public TodoController(ITodoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetByName([FromQuery]string name, CancellationToken token)
        {
           var  res =  await _service.GetAsync(name, token);

            return Ok(res);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id, CancellationToken token)
        {
           var res = await _service.GetById(id, token);

            return Ok(res);
        }
        

        [HttpPost]
        public async Task<IActionResult> CreateNew(TodoItem item, CancellationToken token)
        {
            await _service.CreateAsync(item, token);
            return Ok();
        }
    }
}