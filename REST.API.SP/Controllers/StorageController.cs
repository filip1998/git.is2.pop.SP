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
    public class StorageController : ControllerBase
    {
        private readonly ILogger<StorageController> _logger;

        SPDbContext spDbContext = new();

        public StorageController(ILogger<StorageController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Storage>? get()
        {
            List<Storage> responseBundle = new();
            if (spDbContext.Storage != null)
                responseBundle = spDbContext.Storage.ToList();
            return responseBundle;
        }


        [HttpGet("{id}")]
        public IEnumerable<Storage>? getById(int id)
        {
            List<Storage> responseBundle = new();
            Storage? storage = spDbContext.Storage.Find(id);
            if (storage != null)
            {
                responseBundle.Add(storage);
                responseBundle = spDbContext.Storage.ToList();
            }
            return responseBundle;
        }

        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {
            Storage? storage = spDbContext.Storage.Find(id);
            if (storage != null)
            {
                spDbContext.Storage.Remove(storage);
                spDbContext.SaveChanges();
                return new OkResult();
            }
            return NotFound();
        }

        [HttpPost]
        public IEnumerable<Storage>? update([FromBody] Storage storage)
        {
            List<Storage> responseBundle = new List<Storage>();
            EntityEntry<Storage>? storedResource;
            if (spDbContext.Storage != null)
            {
                if (storage.Id < 1)
                    storedResource = spDbContext.Storage.Add(storage);
                else
                    storedResource = spDbContext.Storage.Update(storage);
                spDbContext.SaveChanges();
                responseBundle.Add(storedResource.Entity);
            }
            return responseBundle;
        }
    }
}
