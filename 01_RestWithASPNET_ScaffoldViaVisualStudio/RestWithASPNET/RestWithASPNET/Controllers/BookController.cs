using System.Globalization;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Business;
using RestWithASPNET.Model;


namespace RestWithASPNET.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private IBookBusiness _bookBusiness;

        public BookController(ILogger<BookController> logger, IBookBusiness bookBusiness)
        {
            _logger = logger;
            _bookBusiness = bookBusiness;
        }
        #region verbo Get
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _bookBusiness.FindById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            return Ok(_bookBusiness.Create(book));
        }
        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            return Ok(_bookBusiness.Update(book));
        }
        #endregion

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _bookBusiness.Delete(id);
            return NoContent();
        }
    }
}
