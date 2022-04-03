using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SPDataContext.Database;
using SPDataContext;
using Model.SP;

namespace REST.API.SP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : Controller
    {
        private readonly ILogger<ItemController> _logger;

        SPDbContext spDbContext = new();

        public ItemController(ILogger<ItemController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Item>? get()
        {
            List<Item> responseBundle = new();
            if (spDbContext.Item != null)
                responseBundle = spDbContext.Item.ToList();
            return responseBundle;
        }


        [HttpGet("{id}")]
        public IEnumerable<Item>? getById(int id)
        {
            List<Item> responseBundle = new();
            Item? item = spDbContext.Item.Find(id);
            if (item != null)
            {
                responseBundle.Add(item);
                responseBundle = spDbContext.Item.ToList();
            }
            return responseBundle;
        }

        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {
            Item? item = spDbContext.Item.Find(id);
            if (item != null)
            {
                spDbContext.Item.Remove(item);
                spDbContext.SaveChanges();
                return new OkResult();
            }
            return NotFound();
        }

        [HttpPost]
        public IEnumerable<Item>? update([FromBody] Item item)
        {
            List<Item> responseBundle = new List<Item>();
            EntityEntry<Item>? storedResource;
            if (spDbContext.Item != null)
            {
                if (item.Id < 1)
                    storedResource = spDbContext.Item.Add(item);
                else
                    storedResource = spDbContext.Item.Update(item);
                spDbContext.SaveChanges();
                responseBundle.Add(storedResource.Entity);
            }
            return responseBundle;
        }
    }
}
