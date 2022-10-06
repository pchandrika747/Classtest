using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApi_withLTI.Modules;

namespace WebApi_withLTI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public AppDbContext _context { get; }

        [HttpGet]
        public ActionResult get()
        {
            var data = _context.Category.ToList();
            return Ok(data);
        }
        [HttpGetAttribute("{id}")]
        public ActionResult get(int id)
        {
            Category data = _context.Category.FirstOrDefault(p => p.Category_Id == id);
            return Ok(data);
        }
        [HttpPost]
        public ActionResult post(Category newcategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                _context.Category.Add(newcategory);
                _context.SaveChanges();
                return Ok();
            }
        }

        [HttpPut("{id}")]
        public ActionResult put(int? id, Product modifiedproduct)
        {

            if (id == null)
                return NotFound();
            else
            {// select productId,productname,price  from products where productid=id

                var data = _context.Category.FirstOrDefault(c => c.Category_Id == id);
                data.Category_Id = modifiedproduct.Category_Id;
                _context.SaveChanges();
                return Ok();

            }
        }
        [HttpDelete("{id}")]
        public ActionResult delete(int? id)
        {
            if (id == null)
                return NotFound();

            else
            {
                var data = _context.Category.FirstOrDefault(c => c.Category_Id == id);
                _context.Category.Remove(data);
                _context.SaveChanges();
                return Ok();
            }

        }
    }
}
