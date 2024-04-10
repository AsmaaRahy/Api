using Demo.Data;
using Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CategoryController(ApplicationDbContext context)
        {
            this.context=context;
        }

        [HttpGet]

        public IActionResult GetAll() {
            var category = context.Categories.ToList();
            return Ok(category);
        }

        [HttpGet("{id}")]
    public IActionResult GetById(int id) {
            var category = context.Categories.Find(id);
            if(category != null)
            {
                return Ok(category);
            }
            return BadRequest();
        
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(ModelState.IsValid)
            {
                context.Categories.Add(category);
                context.SaveChanges();
                return Created($"https://localhost:7049/api/Category/{category.CategoryId}", category);

            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                var oldCategory = context.Categories.Find(category.CategoryId);

                if (oldCategory != null)
                {
                    oldCategory.CategoryId = category.CategoryId;
                    oldCategory.CategoryName = category.CategoryName;
                    context.SaveChanges();
                    return Ok(category);
                }
                else
                {
                    return NotFound();
                }
            }
                return BadRequest();
            
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var category = context.Categories.Find(id);
            if(category != null )
            {
                context.Categories.Remove(category);
                context.SaveChanges();
                return Ok(category);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
