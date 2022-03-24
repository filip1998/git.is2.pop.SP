using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Model.SP
{
    [Table("item")]
    public class Item : BaseEntity
    {
        [JsonPropertyName("item_code")]
        [Column("item_code")]
        public string ItemCode { get; set; }

        [JsonPropertyName("item_name")]
        [Column("item_name")]
        public string ItemName { get; set; }

        [JsonPropertyName("item_quantity")]
        [Column("item_quantity")]
        public int ItemQuantity { get; set; }


        [JsonPropertyName("item_price")]
        [Column("item_price")]
        public string ItemPrice { get; set; }
        [JsonPropertyName("storage_id")]
        [Column("storage_id")]
        public int StorageId { get; set; }




    }
}
