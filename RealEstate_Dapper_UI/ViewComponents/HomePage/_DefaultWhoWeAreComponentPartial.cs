using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDetailDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultWhoWeAreComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var client2 = _httpClientFactory.CreateClient();

            var responsMessage = await client.GetAsync("https://localhost:7067/api/WhoWeAreDetails");
            var responsMessage2 = await client2.GetAsync("https://localhost:7067/api/Services");

            if (responsMessage.IsSuccessStatusCode && responsMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responsMessage2.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDto>>(jsonData);
                var value2 = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailServicesDto>>(jsonData2);

                ViewBag.title=value.Select(x=>x.Title).FirstOrDefault();
                ViewBag.subTitle=value.Select(x=>x.SubTitle).FirstOrDefault();
                ViewBag.description1=value.Select(x=>x.Description1).FirstOrDefault();
                ViewBag.description2 = value.Select(x=>x.Description2).FirstOrDefault();
                return View(value2);
            }
            return View();
        }
    }
}
