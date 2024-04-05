using System.Text.Json.Serialization;

namespace FooWpf.Model
{
    public class MDNProduct
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("price")]
        public string Price { get; set; } = string.Empty;
        [JsonPropertyName("image")]
        public string Image { get; set; } = string.Empty;
        [JsonPropertyName("type")]
        public string ProductType { get; set; } = string.Empty;
    }
}
