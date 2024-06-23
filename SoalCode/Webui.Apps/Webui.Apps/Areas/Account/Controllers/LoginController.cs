using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Webui.Apps.Models;

namespace Webui.Apps.Areas.Account.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Login/LoginUser")]
        public async Task<IActionResult> LoginUser([FromBody] User user)
        {
            var client = _httpClientFactory.CreateClient();

            var json = JsonSerializer.Serialize(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7065/user/login", content);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var authResponse = JsonSerializer.Deserialize<AuthResponse>(responseString);
                HttpContext.Session.SetString("Token", authResponse!.AccessToken);

                return Json(new { success = true, token = authResponse!.AccessToken, authResponse!.ExpiredAt });
            }

            return Json(new { success = false, message = "Username or Password is incorrect" });
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Index");
        }
    }
}
