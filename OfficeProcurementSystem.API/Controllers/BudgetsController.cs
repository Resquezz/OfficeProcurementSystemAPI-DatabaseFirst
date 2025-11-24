using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OfficeProcurementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetsController : ControllerBase
    {
        private readonly IBudgetService _budgetService;
        public BudgetsController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        // GET: api/<BudgetsController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _budgetService.GetAllBudgetsAsync());
        }

        // GET api/<BudgetsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _budgetService.GetBudgetByIdAsync(id));
        }

        // POST api/<BudgetsController>
        [HttpPost]
        public async Task<IActionResult> Create(CreateBudgetDTO request)
        {
            return Ok(await _budgetService.CreateBudgetAsync(request));
        }

        // PUT api/<BudgetsController>/
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBudgetDTO request)
        {
            return Ok(await _budgetService.UpdateBudgetAsync(request));
        }

        // DELETE api/<BudgetsController>/
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteBudgetDTO request)
        {
            await _budgetService.DeleteBudgetAsync(request);
            return Ok();
        }
    }
}
