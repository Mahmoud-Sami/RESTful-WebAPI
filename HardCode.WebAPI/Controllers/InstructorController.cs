using HardCode.Domain.Dtos.Instructor;
using HardCode.Domain.Entities;
using HardCode.Domain.Interfaces;
using HardCode.Domain.Interfaces.IUnitsOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HardCode.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IServices _services;

        public InstructorController(IServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IEnumerable<InstructorDto>> GetAllInstructors()
        {
            return await _services.Instructor.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<InstructorDto>> GetInstructorById(int id)
        {
            try
            {
                if (!await _services.Instructor.AnyAsync(ins => ins.Id == id))
                    return NotFound();

                return Ok(await _services.Instructor.GetByIdAsync(id));
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult> AddInstructor(CreateInstructorDto instructor)
        {
            if (instructor == null) 
                return BadRequest();

            bool Result = await _services.Instructor.CreateAsync(instructor);
                
            if(!Result)
                return StatusCode(StatusCodes.Status500InternalServerError);

            int? Id = await _services.Instructor.GetIdByEmailAsync(instructor.Email);

            return RedirectToAction(nameof(GetInstructorById), new { id = Id });
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<InstructorDto>> UpdateInstructor(int id, CreateInstructorDto newInstructor)
        {
            if (!_services.Instructor.AnyAsync(ins => ins.Id == id).Result)
                return BadRequest($"Instructor with Id = {id} not found");

            if (newInstructor == null)
                return BadRequest();

            bool Result = await _services.Instructor.UpDateAsync(newInstructor, id);

            if (!Result)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(newInstructor);   
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteInstructor(int id)
        { 
            if (!await _services.Instructor.AnyAsync(ins => ins.Id == id))
                return NotFound($"Instructor with Id = {id} not found");

            bool Result = await _services.Instructor.DeleteAsync(id);

            if(!Result)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok($"Instructor with Id = {id} deleted successfully");
        }

    }
}