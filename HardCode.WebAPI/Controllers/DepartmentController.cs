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
    public class DepartmentController : ControllerBase
    {
        private readonly IRepositories _unitOfWork;
        public DepartmentController(IRepositories unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await _unitOfWork.DepartmentsRepository.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Department>> GetDepartmentById(int id)
        {
            try
            {
                Department department = await _unitOfWork.DepartmentsRepository.GetByIDAsync(id);
                if (department == null)
                    return NotFound();
                else
                    return Ok(department);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult> AddDepartment(Department department)
        {
            try
            {
                if (department == null) 
                    return BadRequest();

                await _unitOfWork.DepartmentsRepository.AddAsync(department);
                await _unitOfWork.SaveAsync();

                return CreatedAtAction(nameof(GetDepartmentById), new { id = department.Id }, department);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Department>> UpdateDepatment(int id, Department newDepartment)
        {
            try
            {
                if (newDepartment == null || id != newDepartment.Id)
                    return BadRequest();

                Department updatedDepartment = 
                    await _unitOfWork.DepartmentsRepository.UpdateDepartmentAsync(newDepartment);
                await _unitOfWork.SaveAsync();

                if (updatedDepartment == null)
                    return BadRequest($"Department with Id = {id} not found");
                else
                    return updatedDepartment;
                
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
                var deletedDepartment = await _unitOfWork.DepartmentsRepository.GetByIDAsync(id);
                if (deletedDepartment == null)
                    return NotFound($"Department with Id = {id} not found");

                _unitOfWork.DepartmentsRepository.Remove(deletedDepartment);
                await _unitOfWork.SaveAsync();
                return Ok($"Department: {deletedDepartment.Name} with Id = {id} deleted successfully");

            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
