using Condominio.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Condominio.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        public CustomerController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient("condominius");
            var response = await client.GetAsync("api/Customer");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var obj = JsonSerializer.Deserialize<List<CustomerViewModel>>(content, new JsonSerializerOptions(JsonSerializerDefaults.Web) { WriteIndented = true });
                return View(obj);
            }
            return View(new List<CustomerViewModel>());
            
        }

        public async Task<IActionResult> Register()
        {
            ViewBag.ResidentialList = await ResidencialLoad();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CustomerViewModel customerViewModel)
        {
            ViewBag.ResidentialList = await ResidencialLoad();
            if (!ModelState.IsValid)
            {                
                return View();
            }

            var condominiumJson = new StringContent(JsonSerializer.Serialize(customerViewModel), Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient("condominius");
            var response = await client.PostAsync("api/Customer", condominiumJson);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.ResidentialList = await ResidencialLoad();
            var client = _clientFactory.CreateClient("condominius");
            var response = await client.GetAsync($"api/Customer/GetById?customerId={id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var obj = JsonSerializer.Deserialize<CustomerViewModel>(content, new JsonSerializerOptions(JsonSerializerDefaults.Web) { WriteIndented = true });
                return View(obj);
            }

            return View(new CustomerViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CustomerViewModel  customerViewModel)
        {
            ViewBag.ResidentialList = await ResidencialLoad();
            
            if (!ModelState.IsValid)
            {
                return View();
            }

            var condominiumJson = new StringContent(JsonSerializer.Serialize(customerViewModel), Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient("condominius");
            var response = await client.PutAsync("api/Customer", condominiumJson);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _clientFactory.CreateClient("condominius");
            var response = await client.DeleteAsync($"api/Customer?customerId={id}");
            if (response.IsSuccessStatusCode)
            {
                return Json(new { message = "Eliminado", success = true });
            }

            return Json(new { message = "algo paso", success = false });
        }

        public async Task<IActionResult> Detail(int id)
        {
            var client = _clientFactory.CreateClient("condominius");
            var response = await client.GetAsync($"api/Customer/GetById?customerId={id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var obj = JsonSerializer.Deserialize<CustomerViewModel>(content, new JsonSerializerOptions(JsonSerializerDefaults.Web) { WriteIndented = true });
                obj.Dues = await DueLoad(id);
                obj.Payments = await PaymentLoad(id);
                return View(obj);
            }

            return View(new CustomerViewModel());
        }

        #region Method Private
        private async Task<List<ResidencialViewModel>> ResidencialLoad()
        {            
            var client = _clientFactory.CreateClient("condominius");
            var response = await client.GetAsync("api/Residencial");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var obj = JsonSerializer.Deserialize<List<ResidencialViewModel>>(content, new JsonSerializerOptions(JsonSerializerDefaults.Web) { WriteIndented = true });
                return obj;
            }

            return new List<ResidencialViewModel>();
        }

        private async Task<List<DueViewModel>> DueLoad(int customerId)
        {
            var client = _clientFactory.CreateClient("condominius");
            var response = await client.GetAsync($"api/Due/GetListByCustomerId?customerid={customerId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var obj = JsonSerializer.Deserialize<List<DueViewModel>>(content, new JsonSerializerOptions(JsonSerializerDefaults.Web) { WriteIndented = true });                
                return obj;
            }

            return new List<DueViewModel>();
        }

        private async Task<List<PaymentViewModel>> PaymentLoad(int customerId)
        {
            var client = _clientFactory.CreateClient("condominius");
            var response = await client.GetAsync($"api/Payment/GetListByCustomerId?customerid={customerId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var obj = JsonSerializer.Deserialize<List<PaymentViewModel>>(content, new JsonSerializerOptions(JsonSerializerDefaults.Web) { WriteIndented = true });
                return obj;
            }

            return new List<PaymentViewModel>();
        }
        #endregion
    }
}
