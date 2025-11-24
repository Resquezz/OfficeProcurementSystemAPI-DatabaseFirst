using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OfficeProcurementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAllCategoriesAsync());
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _categoryService.GetCategoryByIdAsync(id));
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDTO request)
        {
            return Ok(await _categoryService.CreateCategoryAsync(request));
        }

        // PUT api/<CategoriesController>/
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDTO request)
        {
            return Ok(await _categoryService.UpdateCategoryAsync(request));
        }

        // DELETE api/<CategoriesController>/
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCategoryDTO request)
        {
            await _categoryService.DeleteCategoryAsync(request);
            return Ok();
        }
    }
}
