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
    public class DocumentController : Controller
    {
        private readonly ILogger<DocumentController> _logger;

        SPDbContext spDbContext = new();

        public DocumentController(ILogger<DocumentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Document>? get()
        {
            List<Document> responseBundle = new();
            if (spDbContext.Document != null)
                responseBundle = spDbContext.Document.ToList();
            return responseBundle;
        }


        [HttpGet("{id}")]
        public IEnumerable<Document>? getById(int id)
        {
            List<Document> responseBundle = new();
            Document? document = spDbContext.Document.Find(id);
            if (document != null)
            {
                responseBundle.Add(document);
                responseBundle = spDbContext.Document.ToList();
            }
            return responseBundle;
        }

        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {
            Document? document = spDbContext.Document.Find(id);
            if (document != null)
            {
                spDbContext.Document.Remove(document);
                spDbContext.SaveChanges();
                return new OkResult();
            }
            return NotFound();
        }

        [HttpPost]
        public IEnumerable<Document>? update([FromBody] Document document)
        {
            List<Document> responseBundle = new List<Document>();
            EntityEntry<Document>? storedResource;
            if (spDbContext.Document != null)
            {
                if (document.Id < 1)
                    storedResource = spDbContext.Document.Add(document);
                else
                    storedResource = spDbContext.Document.Update(document);
                spDbContext.SaveChanges();
                responseBundle.Add(storedResource.Entity);
            }
            return responseBundle;
        }
    }
}
