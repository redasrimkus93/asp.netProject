using System.Text.Json.Serialization;

namespace WebApplication1.Model
{
    public class Product
    {
        public string Id { get; set; }
        public string Maker { get; set; }
        [JsonPropertyName("img")]
        public string Image { get; set; }
        public int[] Ratings { get; set; }
    }
}
