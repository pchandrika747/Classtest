using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApi_withLTI.Modules;

namespace WebApi_withLTI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public AppDbContext _context { get; }

        [HttpGet]
        public ActionResult get()
        {
            var data = _context.Product.ToList();
            return Ok(data);
        }
        [HttpGetAttribute("{id}")]
        public ActionResult get(int id)
        {
            var data = _context.Product.FirstOrDefault(p => p.Product_Id == id);
            return Ok(data);
        }
        [HttpPost]
        public ActionResult post(Product newproduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                _context.Product.Add(newproduct);
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

                var data = _context.Product.FirstOrDefault(p => p.Product_Id == id);
                data.Product_Name = modifiedproduct.Product_Name;
                data.Product_Price = modifiedproduct.Product_Price;

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
                var data = _context.Product.FirstOrDefault(p => p.Product_Id == id);
                _context.Product.Remove(data);
                _context.SaveChanges();
                return Ok();
            }

        }
    }

}
