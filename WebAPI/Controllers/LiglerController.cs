using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiglerController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public LiglerController(ApplicationContext context)
        {
            _context = context;

        }


        [HttpGet]
        public IActionResult GetSp()
        {
            return Ok(_context.Liglers.ToList());
        }

        //api/products?id=1
        //api/products/1
        [HttpPut("{id}")]
        public IActionResult Updatespr(int id, Ligler ligler)
        {
            var update = _context.Liglers.FirstOrDefault(I => I.LId == id);
            update.LigAd =ligler.LigAd;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletespr(int id)
        {
            var delete = _context.Liglers.FirstOrDefault(I => I.LId == id);
            _context.Remove(delete);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPost]
        public IActionResult Addspr(Ligler ligler)
        {
            _context.Add(ligler);
            _context.SaveChanges();
            return Created("", ligler);
        }

        //api/products/GetsprById/1
        [HttpGet("{id}")]
        public IActionResult GetsprById(int id)
        {
            return Ok(_context.Liglers.FirstOrDefault(I => I.LId == id));
        }
    }
}
