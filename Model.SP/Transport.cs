using Model.SP;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Model.SP
{
    [Table("transport")]
    public class Transport : BaseEntity
    {
        [JsonPropertyName("transport_id")]
        [Column("transport_id")]
        public int TransportId { get; set; }

        [JsonPropertyName("document_id")]
        [Column("document_id")]
        public int DocumentId { get; set; }

        [JsonPropertyName("storage_id")]
        [Column("storage_id")]
        public int StorageId { get; set; }

    }
}
