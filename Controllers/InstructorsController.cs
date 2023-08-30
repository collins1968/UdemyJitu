using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using UdemyJitu.Entities;
using UdemyJitu.Request;
using UdemyJitu.Responses;
using UdemyJitu.Services.IServices;

namespace UdemyJitu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IInstructorService instructorService;

        public InstructorsController(IMapper mapper, IInstructorService instructorService)
        {
            mapper = mapper;
            instructorService = instructorService;
        }


        [HttpPost]
        public async Task<ActionResult<SuccessMessage>> AddInstructor(AddInstructor newInstructor)
        {
            var instructor = mapper.Map<Instructor>(newInstructor);
            var result = await instructorService.AddInstructorAsync(instructor);
            var response = new SuccessMessage(200, result);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<SuccessMessage>> GetAllInstructors()
        {
            var result = await instructorService.GetAllInstructorsAsync();
            var instructors = mapper.Map<IEnumerable<InstructorResponse>>(result);
            return Ok(instructors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuccessMessage>> GetInstructorById(Guid id)
        {
            var result = await instructorService.GetInstructorByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            var instructor = mapper.Map<InstructorResponse>(result);
            return Ok(instructor);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SuccessMessage>> DeleteInstructor(Guid id)
        {
            var instructor = await instructorService.GetInstructorByIdAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            var result = await instructorService.DeleteInstructorAsync(instructor);
            var response = new SuccessMessage(200, result);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SuccessMessage>> UpdateInstructor(Guid id, AddInstructor updateInstructor)
        {
            var instructor = await instructorService.GetInstructorByIdAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            var result = await instructorService.UpdateInstructorAsync(instructor);
            var response = new SuccessMessage(200, result);
            return Ok(response);
        }
    }
}
