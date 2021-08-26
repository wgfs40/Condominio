using Condominio.Applications.Interfaces;
using Condominio.Applications.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Condominio.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CondominiumController : ControllerBase
    {
        private readonly ICondominiusAppService _condominiusAppService;

        public CondominiumController(ICondominiusAppService condominiusAppService)
        {
            _condominiusAppService = condominiusAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var lista = await _condominiusAppService.GetAll();
            return Ok(lista);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int condominiumId)
        {
            var lista = await _condominiusAppService.GetById(condominiumId);
            return Ok(lista);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]CondominiumViewModel condominiumViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var isRegister = await _condominiusAppService.Register(condominiumViewModel);
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
        public async Task<IActionResult> Modify([FromBody] CondominiumViewModel condominiumViewModel)
        {
            var isRegister = await _condominiusAppService.Update(condominiumViewModel);
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
        public async Task<IActionResult> Delete(int condominiuId)
        {
            var isRegister = await _condominiusAppService.Remove(condominiuId);
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
