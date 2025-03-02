using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.ContactDtos;

namespace WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7206/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDTO createContactDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDTO);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7206/api/Contact", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7206/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7206/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateContactDTO>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDTO updateContactDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateContactDTO);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7206/api/Contact", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
