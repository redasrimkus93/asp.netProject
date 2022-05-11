using System.Text.Json;
using WebApplication1.Model;

namespace WebApplication1.Services
{
    public class ProductsService
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductsService(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public Product[] GetProducts()
        {
            var path = Path.Combine(webHostEnvironment.WebRootPath, "data", "products.json");
            using (var fileReader = File.OpenText(path))
            {
                return JsonSerializer.Deserialize<Product[]>(fileReader.ReadToEnd(),
                    new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true,
                    });
            }
        }

        public void AddRating(string productId, int rating)
        {
            var products = GetProducts();

            var product = products.First(x => x.Id == productId);

            if (product.Ratings == null)
            {
                product.Ratings = new int[] { rating };
            }
            else
            {
                var ratings = product.Ratings.ToList();
                ratings.Add(rating);
                product.Ratings = ratings.ToArray();
            }

            using (var outputStream = File.OpenWrite("wwwroot/data/products.json"))
            {
                JsonSerializer.Serialize<Product[]>(new Utf8JsonWriter(outputStream, new JsonWriterOptions
                {
                    SkipValidation = true,
                    Indented = true
                }), products);
            }
        }
    }
}
