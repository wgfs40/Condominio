using Condominio.Applications.Interfaces;
using Condominio.Applications.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Condominio.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DueController : ControllerBase
    {
        private readonly IDueAppService  _dueAppService;

        public DueController(IDueAppService dueAppService)
        {
            _dueAppService = dueAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var lista = await _dueAppService.GetAll();
            return Ok(lista);
        }

        [HttpGet("GetListByCustomerId")]
        public async Task<IActionResult> GetListByCustomerId(int customerid)
        {
            var lista = await _dueAppService.GetAllByCustomerId(customerid);
            return Ok(lista);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] DueViewModel dueViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var isRegister = await _dueAppService.Register(dueViewModel);
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
        public async Task<IActionResult> Modify([FromBody] DueViewModel dueViewModel)
        {
            var isRegister = await _dueAppService.Update(dueViewModel);
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
        public async Task<IActionResult> Delete(int dueId)
        {
            var isRegister = await _dueAppService.Remove(dueId);
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
