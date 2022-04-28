using HardCode.Domain.Entities;
using HardCode.Domain.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;
        public InstructorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<Instructor>> GetAllInstructors()
        {
            return await _unitOfWork.InstructorsRepository.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Instructor>> GetInstructorById(int id)
        {
            try
            {
                Instructor instructor = await _unitOfWork.InstructorsRepository.GetInstructorByIdAsync(id);
                if (instructor == null)
                    return NotFound();
                else
                    return Ok(instructor);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult> AddInstructor(Instructor instructor)
        {
            try
            {
                if (instructor == null) 
                    return BadRequest();

                instructor.Department = null;
                await _unitOfWork.InstructorsRepository.AddAsync(instructor);
                await _unitOfWork.SaveAsync();

                return CreatedAtAction(nameof(GetInstructorById), new { id = instructor.Id }, instructor);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Instructor>> UpdateInstructor(int id, Instructor newInstructor)
        {
            try
            {
                if (newInstructor == null || id != newInstructor.Id)
                    return BadRequest();

                Instructor updatedInstructor = 
                    await _unitOfWork.InstructorsRepository.UpdateInstructorAsync(newInstructor);
                await _unitOfWork.SaveAsync();

                if (updatedInstructor == null)
                    return BadRequest($"Instructor with Id = {id} not found");
                else
                    return updatedInstructor;
                
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteInstructor(int id)
        {
            try
            {
                var deletedInstructor = await _unitOfWork.InstructorsRepository.GetByIDAsync(id);
                if (deletedInstructor == null)
                    return NotFound($"Instructor with Id = {id} not found");

                _unitOfWork.InstructorsRepository.Remove(deletedInstructor);
                await _unitOfWork.SaveAsync();
                return Ok($"Instructor with Id = {id} deleted successfully");

            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
