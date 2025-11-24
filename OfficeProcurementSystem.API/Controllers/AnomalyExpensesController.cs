using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OfficeProcurementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnomalyExpensesController : ControllerBase
    {
        private readonly IAnomalyExpenseService _anomalyExpenseService;
        public AnomalyExpensesController(IAnomalyExpenseService anomalyExpenseService)
        {
            _anomalyExpenseService = anomalyExpenseService;
        }

        // GET: api/<AnomalyExpensesController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _anomalyExpenseService.GetAllAnomalyExpensesAsync());
        }

        // GET api/<AnomalyExpensesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _anomalyExpenseService.GetAnomalyExpenseByIdAsync(id));
        }

        // POST api/<AnomalyExpensesController>
        [HttpPost]
        public async Task<IActionResult> Create(CreateAnomalyExpenseDTO request)
        {
            return Ok(await _anomalyExpenseService.CreateAnomalyExpenseAsync(request));
        }

        // PUT api/<AnomalyExpensesController>/
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAnomalyExpenseDTO request)
        {
            return Ok(await _anomalyExpenseService.UpdateAnomalyExpenseAsync(request));
        }

        // DELETE api/<AnomalyExpensesController>/
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteAnomalyExpenseDTO request)
        {
            await _anomalyExpenseService.DeleteAnomalyExpenseAsync(request);
            return Ok();
        }
    }
}
