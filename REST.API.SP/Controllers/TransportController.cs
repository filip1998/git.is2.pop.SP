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
    public class TransportController : Controller
    {
        private readonly ILogger<TransportController> _logger;

        SPDbContext spDbContext = new();
        public TransportController(ILogger<TransportController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Transport>? get()
        {
            List<Transport> responseBundle = new();
            if (spDbContext.Transport != null)
                responseBundle = spDbContext.Transport.ToList();
            return responseBundle;
        }


        [HttpGet("{id}")]
        public IEnumerable<Transport>? getById(int id)
        {
            List<Transport> responseBundle = new();
            Transport? transport = spDbContext.Transport.Find(id);
            if (transport != null)
            {
                responseBundle.Add(transport);
                responseBundle = spDbContext.Transport.ToList();
            }
            return responseBundle;
        }

        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {
            Transport? transport = spDbContext.Transport.Find(id);
            if (transport != null)
            {
                spDbContext.Transport.Remove(transport);
                spDbContext.SaveChanges();
                return new OkResult();
            }
            return NotFound();
        }

        [HttpPost]
        public IEnumerable<Transport>? update([FromBody] Transport transport)
        {
            List<Transport> responseBundle = new List<Transport>();
            EntityEntry<Transport>? storedResource;
            if (spDbContext.Transport != null)
            {
                if (transport.Id < 1)
                    storedResource = spDbContext.Transport.Add(transport);
                else
                    storedResource = spDbContext.Transport.Update(transport);
                spDbContext.SaveChanges();
                responseBundle.Add(storedResource.Entity);
            }
            return responseBundle;
        }
    }
}
