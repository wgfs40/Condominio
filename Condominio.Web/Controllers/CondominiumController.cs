using Condominio.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Condominio.Web.Controllers
{
    public class CondominiumController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        public CondominiumController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient("condominius");
            var response = await client.GetAsync("api/Condominium");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var obj = JsonSerializer.Deserialize<List<CondominiumViewModel>>(content, new JsonSerializerOptions(JsonSerializerDefaults.Web) { WriteIndented = true });
                return View(obj);
            }
            return View(new List<CondominiumViewModel>());
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CondominiumViewModel condominiumViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var condominiumJson = new StringContent(JsonSerializer.Serialize(condominiumViewModel),Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient("condominius");
            var response = await client.PostAsync("api/Condominium", condominiumJson);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = _clientFactory.CreateClient("condominius");
            var response = await client.GetAsync($"api/Condominium/GetById?condominiumId={id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var obj = JsonSerializer.Deserialize<CondominiumViewModel>(content, new JsonSerializerOptions(JsonSerializerDefaults.Web) { WriteIndented = true });
                return View(obj);
            }

            return View(new CondominiumViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CondominiumViewModel condominiumViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var condominiumJson = new StringContent(JsonSerializer.Serialize(condominiumViewModel), Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient("condominius");
            var response = await client.PutAsync("api/Condominium", condominiumJson);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(new CondominiumViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _clientFactory.CreateClient("condominius");
            var response = await client.DeleteAsync($"api/Condominium?condominiuId={id}");
            if (response.IsSuccessStatusCode)
            {                
                return Json(new { message = "Eliminado", success = true});
            }

            return Json(new { message = "algo paso" , success = false});
        }
    }
}
