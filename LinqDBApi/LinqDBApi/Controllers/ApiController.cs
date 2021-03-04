using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqDBApi.DataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LinqDBApi.Controllers
{
    [ApiController]
    [Route("api")]
    [Produces("application/json")]
    public class ApiController : ControllerBase
    {
       // private readonly IConfiguration _configuration;
        private readonly Student _student;
        private readonly PracticeDbContext _db;

        public ApiController(/*IConfiguration configuration ,*/ Student student , PracticeDbContext db)
        {
            _student = student;
            //_configuration = configuration;
            _db = db;
        }

        // GET: api/<ApiController>
        [HttpGet("get")]
        public async Task<List<Student>> Get()
        {
            try
            {
                //_student.Db = _db;
                var list = await _student.getAsync().ConfigureAwait(false);
                return list;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        //// GET api/<ApiController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ApiController>
        //[HttpPost("post")]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ApiController>/5
        //[HttpPut("put/{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ApiController>/5
        //[HttpDelete("delete/{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
