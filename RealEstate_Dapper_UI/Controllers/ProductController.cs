using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7067/api/Products/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProduct)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProduct);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7067/api/Product", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["ekle"] = " ";
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> ProductCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.DeleteAsync($"https://localhost:7067/api/Product/{id}");
            if (reponseMessage.IsSuccessStatusCode)
            {
                TempData["sil"] = " ";
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
