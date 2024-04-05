using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FooWpf.Model
{
    public class MDNProducts
    {
        [JsonPropertyName("products")]
        public List<MDNProduct> Products { get; set; } = new List<MDNProduct>();
    }
}