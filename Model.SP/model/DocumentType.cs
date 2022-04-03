using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Model.SP
{
    [Table("document_type")]
    public class DocumentType : BaseEntity
    {
        [JsonPropertyName("document_type_name")]
        [Column("document_type_name")]
        public string DocumentTypeName { get; set; }

    }
}
