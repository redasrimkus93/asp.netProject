using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Model;
using WebApplication1.Services;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ProductsService ProductsService;
        public Product[] Products { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ProductsService productsService)
        {
            _logger = logger;
            ProductsService = productsService;
        }


        public void OnGet()
        {
            Products = ProductsService.GetProducts();
        }
    }
}