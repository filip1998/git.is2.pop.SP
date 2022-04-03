using Model.SP;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace Model.SP
{
    [Table("dokument")]
    public class Document : BaseEntity
    {
        [JsonPropertyName("document_type_id")]
        [Column("document_type_id")]
        public int DocumentTypeId { get; set; }

        [JsonPropertyName("quantity_of_items")]
        [Column("quantity_of_items")]
        public int QuantityOfItems { get; set; }

        [JsonPropertyName("item_id")]
        [Column("item_id")]
        public int ItemId { get; set; }

        [JsonPropertyName("price_total")]
        [Column("price_total")]
        public Double PriceTotal { get; set; }

        [JsonPropertyName("date")]
        [Column("date")]
        public DateTime Date { get; set; }
    }
}

