using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OfficeProcurementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseReportsController : ControllerBase
    {
        private readonly IExpenseReportService _expenseReportService;
        public ExpenseReportsController(IExpenseReportService expenseReportService)
        {
            _expenseReportService = expenseReportService;
        }

        // GET: api/<ExpenseReportsController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _expenseReportService.GetAllReportsAsync());
        }

        // GET api/<ExpenseReportsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _expenseReportService.GetReportByIdAsync(id));
        }

        // POST api/<ExpenseReportsController>
        [HttpPost]
        public async Task<IActionResult> Create(CreateReportDTO request)
        {
            return Ok(await _expenseReportService.CreateReportAsync(request));
        }

        // PUT api/<ExpenseReportsController>/
        [HttpPut]
        public async Task<IActionResult> Update(UpdateReportDTO request)
        {
            return Ok(await _expenseReportService.UpdateReportAsync(request));
        }

        // DELETE api/<ExpenseReportsController>/
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteReportDTO request)
        {
            await _expenseReportService.DeleteReportAsync(request);
            return Ok();
        }
    }
}
