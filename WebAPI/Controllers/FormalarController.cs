using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using System.Linq;

namespace WebAPI.Controllers
{ 

    [Route("api/[controller]")]
    [ApiController]
    public class FormalarController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public FormalarController(ApplicationContext context)
        {
            _context = context;

        }


        [HttpGet]
        public IActionResult GetSp()
        {
            return Ok(_context.Formalars.ToList());
        }

        //api/products?id=1
        //api/products/1
        [HttpPut("{id}")]
        public IActionResult Updatespr(int id, Formalar formalar)
        {
            var update = _context.Formalars.FirstOrDefault(I => I.Id == id);
            update.Renk = formalar.Renk;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletespr(int id)
        {
            var delete = _context.Formalars.FirstOrDefault(I => I.Id == id);
            _context.Remove(delete);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPost]
        public IActionResult Addspr(Formalar formalar)
        {
            _context.Add(formalar);
            _context.SaveChanges();
            return Created("", formalar);
        }

        //api/products/GetsprById/1
        [HttpGet("{id}")]
        public IActionResult GetsprById(int id)
        {
            return Ok(_context.Formalars.FirstOrDefault(I => I.Id == id));
        }
    }
}
