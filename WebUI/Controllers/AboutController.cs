using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.AboutDtos;

namespace WebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7206/api/About");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDTO createAboutDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createAboutDTO);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7206/api/About", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7206/api/About/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7206/api/About/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateAboutDTO>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDTO updateAboutDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateAboutDTO);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7206/api/About", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
