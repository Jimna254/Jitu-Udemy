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
    public class InstructorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IInstructorSevices _instructorSevices;
        public InstructorController(IMapper mapper, IInstructorSevices instructorServices)
        {

            _mapper = mapper;
            _instructorSevices = instructorServices;

        }

        [HttpPost]
        public async Task<ActionResult<ResponseMessage>> AddInstructor(AddInstructor newinstructor)
        {
            var instructor = _mapper.Map<Instructor>(newinstructor);
            var res = await _instructorSevices.AddInstructorAsync(instructor);
            return CreatedAtAction(nameof(AddInstructor), new ResponseMessage(201, res));

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstructorResponse>>> GetAllInstructorsAsync()
        {
            var response = await _instructorSevices.GetAllInstructorsAsync();
            var instructors = _mapper.Map<IEnumerable<InstructorResponse>>(response);
            return Ok(instructors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InstructorResponse>> GetInstructor(Guid id)
        {
            var response = await _instructorSevices.GetInsructorAsync(id);
            if (response == null)
            {

                return BadRequest(new ResponseMessage(400, "Cannot be null enter again"));
            }
            var instructor = _mapper.Map<InstructorResponse>(response);
            return Ok(instructor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseMessage>> UpdateInstructor(Guid id, AddInstructor UpdatedInstructor)
        {
            var response = await _instructorSevices.GetInsructorAsync(id);
            if (response == null)
            {
                return NotFound(new ResponseMessage(404, "User Does Not Exist"));
            }
            //update
            var updated = _mapper.Map(UpdatedInstructor, response);
            var res = await _instructorSevices.UpdateInstructorAsync(updated);
            return Ok(new ResponseMessage(204, res));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseMessage>> DeleteInstructor(Guid id)
        {
            var response = await _instructorSevices.GetInsructorAsync(id);
            if (response == null)
            {
                return NotFound(new ResponseMessage(404, "Instructor Does Not Exist"));
            }
            //delete

            var res = await _instructorSevices.DeleteInstructorAsync(response);
            return Ok(new ResponseMessage(204, res));
        }
    }
}
