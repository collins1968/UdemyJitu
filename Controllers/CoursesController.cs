using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyJitu.Entities;
using UdemyJitu.Request;
using UdemyJitu.Responses;
using UdemyJitu.Services.IServices;

namespace UdemyJitu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesService coursesService;
        private readonly IMapper mapper;

        public CoursesController(ICoursesService coursesService, IMapper mapper)
        {
            this.coursesService = coursesService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<SuccessMessage>> CreateCourse(AddCourse newCourse)
        {
            var course = mapper.Map<Course>(newCourse);
            var result = await coursesService.CreateCourse(course);
            var response = new SuccessMessage(200, result);
            return Ok(response);
        }
        
        [HttpGet]
        public async Task<ActionResult<SuccessMessage>> GetAllCourses()
        {
            var result = await coursesService.GetAllCourses();
            var courses = mapper.Map<IEnumerable<CourseResponse>>(result);
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuccessMessage>> GetCourseById(Guid id)
        {
            var result = await coursesService.GetCoursebyId(id);
            if (result == null)
            {
                return NotFound();
            }
            var course = mapper.Map<CourseResponse>(result);
            return Ok(course);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<SuccessMessage>> DeleteCourse(Guid id)
        {
            var course = await coursesService.GetCoursebyId(id);
            if (course == null)
            {
                return NotFound();
            }
            var result = await coursesService.DeleteCourse(course);
            var response = new SuccessMessage(200, result);
            return Ok(response);
        }

        /*
        [HttpPut("{id}")]
        public async Task<ActionResult<SuccessMessage>> UpdateCourse(Guid id, UpdateCourse updateCourse)
        {
            var course = await coursesService.GetCoursebyId(id);
            if (course == null)
            {
                return NotFound();
            }
            var newCourse = mapper.Map(updateCourse, course);
            var result = await coursesService.UpdateCourse(newCourse);
            var response = new SuccessMessage(200, result);
            return Ok(response);
        }
        */
    }
}
