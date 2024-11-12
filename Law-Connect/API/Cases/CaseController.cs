using Microsoft.AspNetCore.Mvc;
using Law_Connect.Cases.Application.Services;
using Law_Connect.Cases.Application.DTOs;
using System.Threading.Tasks;

namespace Law_Connect.API.Cases
{
    [ApiController]
    [Route("api/[controller]")]
    public class CaseController : ControllerBase
    {
        private readonly CaseService _caseService;

        public CaseController(CaseService caseService)
        {
            _caseService = caseService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCase(CaseDTO caseDto)
        {
            var result = await _caseService.CreateCaseAsync(caseDto);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCaseById(int id)
        {
            var caseDto = await _caseService.GetCaseByIdAsync(id);
            if (caseDto == null)
                return NotFound();

            return Ok(caseDto);
        }
    }
}
