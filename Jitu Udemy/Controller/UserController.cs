using AutoMapper;
using Jitu_Udemy.Entities;
using Jitu_Udemy.Requests;
using Jitu_Udemy.Responses;
using Jitu_Udemy.Services;
using Jitu_Udemy.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jitu_Udemy.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserServices _userSevices;

        public UserController(IUserServices service, IMapper mapper)
        {
            _mapper = mapper;
            _userSevices = service;
        }
        [HttpPost]
        public async Task<ActionResult<ResponseMessage>> AddUser(AddUser newUser)
        {
            var user = _mapper.Map<User>(newUser);
            var res = await _userSevices.AddUserAsync(user);
            return CreatedAtAction(nameof(AddUser),new ResponseMessage (201 , res));

        }

        [HttpGet]
       public async Task<ActionResult<IEnumerable<UserResponse>>> GetAllUsersAsync()
        {
            var response = await _userSevices.GetAllUsersAsync();
            var users = _mapper.Map<IEnumerable<UserResponse>>(response);
            return Ok(users);
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<UserResponse>> GetUser(Guid id)
        {
            var response = await _userSevices.GetUserAsync(id);
            if (response == null)
            {
                
                return BadRequest(new ResponseMessage(400 , "Cannot be null enter again"));
            }
            var user = _mapper.Map<UserResponse>(response);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseMessage>> UpdateUser(Guid id, AddUser UpdatedUser)
        {
            var response = await _userSevices.GetUserAsync(id);
            if (response == null)
            {
                return NotFound(new ResponseMessage(404, "User Does Not Exist"));
            }
            //update
            var updated = _mapper.Map(UpdatedUser, response);
            var res = await _userSevices.UpdateUserAsync(updated);
            return Ok(new ResponseMessage(204, res));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseMessage>>DeleteUser(Guid id)
        {
            var response = await _userSevices.GetUserAsync(id);
            if (response == null)
            {
                return NotFound(new ResponseMessage(404, "User Does Not Exist"));
            }
            //delete
         
            var res = await _userSevices.DeleteUserAsync(response);
            return Ok(new ResponseMessage(204, res));
        }




    }
}

