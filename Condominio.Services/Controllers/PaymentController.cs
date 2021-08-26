using Condominio.Applications.Interfaces;
using Condominio.Applications.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Condominio.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentAppService _paymentAppService;

        public PaymentController(IPaymentAppService paymentAppService)
        {
            _paymentAppService = paymentAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var lista = await _paymentAppService.GetAll();
            return Ok(lista);
        }

        [HttpGet("GetListByCustomerId")]
        public async Task<IActionResult> GetListByCustomerId(int customerid)
        {
            var lista = await _paymentAppService.GetAllByCustomerId(customerid);
            return Ok(lista);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] PaymentViewModel paymentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var isRegister = await _paymentAppService.Register(paymentViewModel);
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
        public async Task<IActionResult> Modify([FromBody] PaymentViewModel paymentViewModel)
        {
            var isRegister = await _paymentAppService.Update(paymentViewModel);
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
        public async Task<IActionResult> Delete(int paymentId)
        {
            var isRegister = await _paymentAppService.Remove(paymentId);
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
