using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers //which routes available to listen on in web api
{
  [Route("api/[controller]")] //controller is placeholder
  [ApiController]
  public class ValuesController : ControllerBase //api/values/
  {
    private readonly DataContext _context;

    public ValuesController(DataContext context)
    {
      _context = context;

    }
    // GET api/values
    [HttpGet]
    //Task enables asynchronous
    public async Task<IActionResult> GetValues() //IActionResult allows returning HTTP responses to client
    {
      var values = await _context.Values.ToListAsync();
      return Ok(values); //return values to client
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetValue(int id)
    {
      //value will match the parameter int id value
      //x represents returning value (ie the id in parameter)
      var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
      return Ok(value);
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}