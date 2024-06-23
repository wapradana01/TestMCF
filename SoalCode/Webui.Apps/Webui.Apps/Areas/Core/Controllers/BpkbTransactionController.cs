using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using Webui.Apps.Models;

namespace Webui.Apps.Areas.Core.Controllers
{
    public class BpkbTransactionController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BpkbTransactionController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            return View(await GetDataItemsAsync());
        }

        public async Task<IActionResult> Create()
        {
            var locations = await GetLocationsAsync();
            ViewBag.Locations = locations;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BpkbTransaction dataItem)
        {
            if (ModelState.IsValid)
            {
                var token = HttpContext.Session.GetString("Token");
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = await client.PostAsJsonAsync("https://localhost:7065/transaction/createBpkb", dataItem); // Ganti dengan URL API yang sesuai
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, "Failed to add data");
            }
            return View(dataItem);
        }

        private async Task<List<BpkbTransaction>> GetDataItemsAsync()
        {
            var token = HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetStringAsync("https://localhost:7065/transaction/getbpkbtransaction"); // Ganti dengan URL API yang sesuai
            return JsonConvert.DeserializeObject<List<BpkbTransaction>>(response)!;
        }

        private async Task<List<Location>> GetLocationsAsync()
        {
            var token = HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetStringAsync("https://localhost:7065/master/getlocation"); // Ganti dengan URL API yang sesuai
            return JsonConvert.DeserializeObject<List<Location>>(response)!;
        }
    }
}
