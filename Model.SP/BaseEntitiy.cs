﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Model.SP
{
    public abstract class BaseEntity
    {
        [Key]
        [Column("id")]
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
