using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OfficeProcurementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAllUsersAsync());
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _userService.GetUserByIdAsync(id));
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDTO request)
        {
            return Ok(await _userService.CreateUserAsync(request));
        }

        // PUT api/<UsersController>/
        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserDTO request)
        {
            return Ok(await _userService.UpdateUserAsync(request));
        }

        // DELETE api/<UsersController>/
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteUserDTO request)
        {
            await _userService.DeleteUserAsync(request);
            return Ok();
        }
    }
}
