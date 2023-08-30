using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyJitu.Entities;
using UdemyJitu.Request;
using UdemyJitu.Responses;
using UdemyJitu.Services;
using UdemyJitu.Services.IServices;

namespace UdemyJitu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            this.mapper = mapper;
            this.userService = userService;
        }

        [HttpPost]
        public async Task <ActionResult<SuccessMessage>> AddUser(AddUser newUser)
        {
            var user = mapper.Map<User>(newUser);
            var result = await userService.AddUserAsync(user);
            var response = new SuccessMessage(200, result);
            return Ok(response);
        }

        [HttpGet]
        public async Task <ActionResult<SuccessMessage>> GetAllUsers()
        {
            var result = await userService.GetAllUsersAsync();
            var users = mapper.Map<IEnumerable<UserResponse>>(result);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<SuccessMessage>> GetUserById(Guid id)
        {
            var result = await userService.GetUserByIdAsync(id);
            if(result == null)
            {
                return NotFound();
            }
            var user = mapper.Map<UserResponse>(result);
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<SuccessMessage>> DeleteUser(Guid id)
        {
            var user = await userService.GetUserByIdAsync(id);
            if(user == null)
            {
                return NotFound();
            }
            var result = await userService.DeleteUserAsync(user);
            var response = new SuccessMessage(200, result);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SuccessMessage>> UpdateUser(Guid id, AddUser updateUser)
        {
            var user = await userService.GetUserByIdAsync(id);
            if(user == null)
            {
                return NotFound();
            }

            var updated = mapper.Map(updateUser, user);
            var res = await userService.UpdateUserAsync(updated);
            return Ok(new SuccessMessage(204, res));

        }

    }
}
