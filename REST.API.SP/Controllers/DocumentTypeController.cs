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
    public class DocumentTypeController : ControllerBase
    {

        private readonly ILogger<DocumentTypeController> _logger;

        SPDbContext spDbContext = new();

        public DocumentTypeController(ILogger<DocumentTypeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<DocumentType>? get()
        {
            List<DocumentType> responseBundle = new();
            if (spDbContext.DocumentType != null)
                responseBundle = spDbContext.DocumentType.ToList();
            return responseBundle;
        }


        [HttpGet("{id}")]
        public IEnumerable<DocumentType>? getById(int id)
        {
            List<DocumentType> responseBundle = new();
            DocumentType? documentType = spDbContext.DocumentType.Find(id);
            if (documentType != null)
            {
                responseBundle.Add(documentType);
                responseBundle = spDbContext.DocumentType.ToList();
            }
            return responseBundle;
        }

        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {
            DocumentType? documentType = spDbContext.DocumentType.Find(id);
            if (documentType != null)
            {
                spDbContext.DocumentType.Remove(documentType);
                spDbContext.SaveChanges();
                return new OkResult();
            }
            return NotFound();
        }

        [HttpPost]
        public IEnumerable<DocumentType>? update([FromBody] DocumentType documentType)
        {
            List<DocumentType> responseBundle = new List<DocumentType>();
            EntityEntry<DocumentType>? storedResource;
            if (spDbContext.DocumentType != null)
            {
                if (documentType.Id < 1)
                    storedResource = spDbContext.DocumentType.Add(documentType);
                else
                    storedResource = spDbContext.DocumentType.Update(documentType);
                spDbContext.SaveChanges();
                responseBundle.Add(storedResource.Entity);
            }
            return responseBundle;
        }
    }
}