using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TakimlarController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public TakimlarController(ApplicationContext context)
        {
            _context = context;

        }


        [HttpGet]
        public IActionResult GetSp()
        {
            return Ok(_context.Takimlars.ToList());
        }

        //api/products?id=1
        //api/products/1
        [HttpPut("{id}")]
        public IActionResult Updatespr(int id, Takimlar takimlar)
        {
            var update = _context.Takimlars.FirstOrDefault(I => I.TID== id);
            update.TakimAdi= takimlar.TakimAdi;
            update.LId= takimlar.LId;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletespr(int id)
        {
            var delete = _context.Takimlars.FirstOrDefault(I => I.TID == id);
            _context.Remove(delete);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPost]
        public IActionResult Addspr(Takimlar takimlar)
        {
            _context.Add(takimlar);
            _context.SaveChanges();
            return Created("", takimlar);
        }

        //api/products/GetsprById/1
        [HttpGet("{id}")]
        public IActionResult GetsprById(int id)
        {
            return Ok(_context.Takimlars.FirstOrDefault(I => I.TID == id));
        }
    }
}
