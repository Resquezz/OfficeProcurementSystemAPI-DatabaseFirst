using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OfficeProcurementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        public SuppliersController(ISupplierService userService)
        {
            _supplierService = userService;
        }

        // GET: api/<SuppliersController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _supplierService.GetAllSuppliersAsync());
        }

        // GET api/<SuppliersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _supplierService.GetSupplierByIdAsync(id));
        }

        // POST api/<SuppliersController>
        [HttpPost]
        public async Task<IActionResult> Create(CreateSupplierDTO request)
        {
            return Ok(await _supplierService.CreateSupplierAsync(request));
        }

        // PUT api/<SuppliersController>/
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSupplierDTO request)
        {
            return Ok(await _supplierService.UpdateSupplierAsync(request));
        }

        // DELETE api/<SuppliersController>/
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteSupplierDTO request)
        {
            await _supplierService.DeleteSupplierAsync(request);
            return Ok();
        }
    }
}
