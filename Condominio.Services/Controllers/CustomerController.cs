using Condominio.Applications.Interfaces;
using Condominio.Applications.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Condominio.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var lista = await _customerAppService.GetAll();
            return Ok(lista);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int customerId)
        {
            var lista = await _customerAppService.GetById(customerId);
            return Ok(lista);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var isRegister = await _customerAppService.Register(customerViewModel);
            if (isRegister)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPut]
        public async Task<IActionResult> Modify([FromBody] CustomerViewModel customerViewModel)
        {
            var isRegister = await _customerAppService.Update(customerViewModel);
            if (isRegister)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int customerId)
        {
            var isRegister = await _customerAppService.Remove(customerId);
            if (isRegister)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
