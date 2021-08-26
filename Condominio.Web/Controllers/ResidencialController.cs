using Condominio.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Condominio.Web.Controllers
{
    public class ResidencialController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public ResidencialController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient("condominius");
            var response = await client.GetAsync("api/Residencial");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var obj = JsonSerializer.Deserialize<List<ResidencialViewModel>>(content, new JsonSerializerOptions(JsonSerializerDefaults.Web) { WriteIndented = true });
                return View(obj);
            }
            return View(new List<ResidencialViewModel>());
        }

        public async Task<IActionResult> Register()
        {
            ViewBag.CondominiusList = await CondominiusLoad();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(ResidencialViewModel residencialViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CondominiusList = await CondominiusLoad();
                return View();
            }

            var condominiumJson = new StringContent(JsonSerializer.Serialize(residencialViewModel), Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient("condominius");
            var response = await client.PostAsync("api/Residencial", condominiumJson);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ViewBag.CondominiusList = await CondominiusLoad();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.CondominiusList = await CondominiusLoad();
            var client = _clientFactory.CreateClient("condominius");
            var response = await client.GetAsync($"api/Residencial/GetById?residencialId={id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var obj = JsonSerializer.Deserialize<ResidencialViewModel>(content, new JsonSerializerOptions(JsonSerializerDefaults.Web) { WriteIndented = true });
                return View(obj);
            }

            return View(new ResidencialViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ResidencialViewModel residencialViewModel)
        {
            ViewBag.CondominiusList = await CondominiusLoad();
            if (!ModelState.IsValid)
            {
                return View();
            }

            var condominiumJson = new StringContent(JsonSerializer.Serialize(residencialViewModel), Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient("condominius");
            var response = await client.PutAsync("api/Residencial", condominiumJson);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(new ResidencialViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _clientFactory.CreateClient("condominius");
            var response = await client.DeleteAsync($"api/Residencial?residencialId={id}");
            if (response.IsSuccessStatusCode)
            {
                return Json(new { message = "Eliminado", success = true });
            }

            return Json(new { message = "algo paso", success = false });
        }

        #region Method Private
        private async Task<List<CondominiumViewModel>> CondominiusLoad()
        {
            var client = _clientFactory.CreateClient("condominius");
            var response = await client.GetAsync("api/Condominium");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var obj = JsonSerializer.Deserialize<List<CondominiumViewModel>>(content, new JsonSerializerOptions(JsonSerializerDefaults.Web) { WriteIndented = true });
                return obj;
            }

            return new List<CondominiumViewModel>();
        } 
        #endregion
    }
}
