using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OfficeProcurementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;
        public PurchasesController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        // GET: api/<PurchasesController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _purchaseService.GetAllPurchasesAsync());
        }

        // GET api/<PurchasesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _purchaseService.GetPurchaseByIdAsync(id));
        }

        // POST api/<PurchasesController>
        [HttpPost]
        public async Task<IActionResult> Create(CreatePurchaseDTO request)
        {
            return Ok(await _purchaseService.CreatePurchaseAsync(request));
        }

        // PUT api/<PurchasesController>/
        [HttpPut]
        public async Task<IActionResult> Update(UpdatePurchaseDTO request)
        {
            return Ok(await _purchaseService.UpdatePurchaseAsync(request));
        }

        // DELETE api/<PurchasesController>/
        [HttpDelete]
        public async Task<IActionResult> Delete(DeletePurchaseDTO request)
        {
            await _purchaseService.DeletePurchaseAsync(request);
            return Ok();
        }
    }
}
