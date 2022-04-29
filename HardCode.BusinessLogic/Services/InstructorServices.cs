using AutoMapper;
using HardCode.Domain.Dtos.Instructor;
using HardCode.Domain.Entities;
using HardCode.Domain.Interfaces;
using HardCode.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HardCode.BusinessLogic.Services
{
    public class InstructorServices : IInstructorServices
    {
        private readonly IRepositories _repositories;
        private readonly IMapper _mapper;

        public InstructorServices(IRepositories repositories, IMapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
        }

        public async Task<bool> AnyAsync(Expression<Func<Instructor, bool>> expression)
            => await _repositories.InstructorsRepository.AnyAsync(expression);

        public async Task<bool> CreateAsync(CreateInstructorDto instructorDto)
        {
            Instructor instructor = _mapper.Map<Instructor>(instructorDto);
            
            try 
            {
                await _repositories.InstructorsRepository.AddAsync(instructor);
                await _repositories.SaveAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Instructor instructor = await _repositories.InstructorsRepository.GetByIDAsync(id);
            
            try
            {
                _repositories.InstructorsRepository.Remove(instructor);
                await _repositories.SaveAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<InstructorDto>> GetAllAsync()
        {
            IEnumerable<Instructor> instructors = await _repositories.InstructorsRepository.GetAllAsync(ins => ins.Department);

            return _mapper.Map<List<InstructorDto>>(instructors);
        }

        public async Task<InstructorDto> GetByIdAsync(int id)
        {
            Instructor instructor = await _repositories.InstructorsRepository.GetByIDAsync(id, ins => ins.Department);

            return _mapper.Map<InstructorDto>(instructor);
        }

        public async Task<int?> GetIdByEmailAsync(string email)
            => await _repositories.InstructorsRepository.GetIdByEmailAsync(email);        

        public async Task<bool> UpDateAsync(CreateInstructorDto instructorDto, int id)
        {
            Instructor instructor = _mapper.Map<Instructor>(instructorDto);
            instructor.Id = id;

            try
            {
                await _repositories.InstructorsRepository.UpdateInstructorAsync(instructor);
                await _repositories.SaveAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
