using Condominio.Applications.Interfaces;
using Condominio.Applications.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Condominio.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResidencialController : ControllerBase
    {
        private readonly IResidencialAppService _residencialAppService;

        public ResidencialController(IResidencialAppService residencialAppService)
        {
            _residencialAppService = residencialAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var lista = await _residencialAppService.GetAll();
            return Ok(lista);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int residencialId)
        {
            var lista = await _residencialAppService.GetById(residencialId);
            return Ok(lista);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] ResidencialViewModel residencialViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var isRegister = await _residencialAppService.Register(residencialViewModel);
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
        public async Task<IActionResult> Modify([FromBody] ResidencialViewModel residencialViewModel)
        {
            var isRegister = await _residencialAppService.Update(residencialViewModel);
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
        public async Task<IActionResult> Delete(int residencialId)
        {
            var isRegister = await _residencialAppService.Remove(residencialId);
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
