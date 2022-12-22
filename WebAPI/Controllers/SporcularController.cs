using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SporcularController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public SporcularController(ApplicationContext context)
        {
            _context = context;

        }


        [HttpGet]
        public IActionResult GetSp()
        {
            return Ok(_context.Sporculars.ToList());
        }

        //api/products?id=1
        //api/products/1
        [HttpPut("{id}")]
        public IActionResult Updatespr(int id, Sporcular sporcular)
        {
            var update = _context.Sporculars.FirstOrDefault(I => I.Id == id);
            update.Adsoyad = sporcular.Adsoyad;
            update.Yas = sporcular.Yas;
            update.Adres = sporcular.Adres;
            update.TID = sporcular.TID;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletespr(int id)
        {
            var delete = _context.Sporculars.FirstOrDefault(I => I.Id == id);
            _context.Remove(delete);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPost]
        public IActionResult Addspr(Sporcular sporcular)
        {
            _context.Add(sporcular);
            _context.SaveChanges();
            return Created("", sporcular);
        }

        //api/products/GetsprById/1
        [HttpGet("{id}")]
        public IActionResult GetsprById(int id)
        {
            return Ok(_context.Sporculars.FirstOrDefault(I => I.Id == id));
        }
    }
}
