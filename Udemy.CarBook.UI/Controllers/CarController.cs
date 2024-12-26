using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Udemy.Carbook.Dto.CarDtos;
using Udemy.Carbook.Dto.ServiceDtos;

namespace Udemy.CarBook.UI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public CarController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7041/api/Car/GetWithBrand");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDtos>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
