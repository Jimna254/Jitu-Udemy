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
    public class CourseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICourseServices _courseSevices;
        public CourseController(IMapper mapper , ICourseServices courseServices) { 
        
            _mapper = mapper;
            _courseSevices = courseServices;
        
        }

        [HttpPost]
        public async Task<ActionResult<ResponseMessage>> AddCourse(AddCourse newcourse)
        {
            var course = _mapper.Map<Course>(newcourse);
            var res = await _courseSevices.AddCourseAsync(course);
            return CreatedAtAction(nameof(AddUser), new ResponseMessage(201, res));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseResponse>>> GetAllCoursesAsync()
        {
            var response = await _courseSevices.GetAllCoursesAsync();
            var courses = _mapper.Map<IEnumerable<CourseResponse>>(response);
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetCourse(Guid id)
        {
            var response = await _courseSevices.GetCourseAsync(id);
            if (response == null)
            {

                return BadRequest(new ResponseMessage(400, "Cannot be null enter again"));
            }
            var course = _mapper.Map<CourseResponse>(response);
            return Ok(course);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseMessage>> UpdateCourse(Guid id, AddCourse UpdatedCourse)
        {
            var response = await _courseSevices.GetCourseAsync(id);
            if (response == null)
            {
                return NotFound(new ResponseMessage(404, "Course Does Not Exist"));
            }
            //update
            var updated = _mapper.Map(UpdatedCourse, response);
            var res = await _courseSevices.UpdateCourseAsync(updated);
            return Ok(new ResponseMessage(204, res));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseMessage>> DeleteCourse(Guid id)
        {
            var response = await _courseSevices.GetCourseAsync(id);
            if (response == null)
            {
                return NotFound(new ResponseMessage(404, "User Does Not Exist"));
            }
            //delete

            var res = await _courseSevices.DeleteCourseAsync(response);
            return Ok(new ResponseMessage(204, res));
        }


    }
}
