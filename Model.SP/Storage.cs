using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Model.SP
{
    [Table("storage")]
    public class Storage : BaseEntity
    {
        [JsonPropertyName("storage_code")]
        [Column("storage_code")]
        public string StorageCode { get; set; }

        [JsonPropertyName("address")]
        [Column("address")]
        public string Address { get; set; }

        [JsonPropertyName("contact")]
        [Column("contact")]
        public string Contact { get; set; }

    }
}
