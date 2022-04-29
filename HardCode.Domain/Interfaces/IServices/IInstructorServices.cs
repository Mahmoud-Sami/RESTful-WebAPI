using HardCode.Domain.Dtos.Instructor;
using HardCode.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HardCode.Domain.Interfaces.IServices
{
    public interface IInstructorServices
    {
        /// <summary>
        ///     Create a new Instructor from CreateInstructorDto.
        /// </summary>
        /// <param name="instructorDto">Expresses InstructorDto</param>
        /// <returns>True In Case Create Successfully, or False In Case Create Failed.</returns>
        Task<bool> CreateAsync(CreateInstructorDto instructorDto);

        /// <summary>
        ///     Get Instructor By Id.
        /// </summary>
        /// <param name="id">Expresses Instructor Id.</param>
        /// <returns>One InstructorDto.</returns>
        Task<InstructorDto> GetByIdAsync(int id);

        /// <summary>
        ///     Get All Instructors.
        /// </summary>
        /// <returns>List of InstructorDto</returns>
        Task<List<InstructorDto>> GetAllAsync();

        /// <summary>
        ///     UpDate Instructor By Instructor ID from CreateInstructorDto. 
        /// </summary>
        /// <param name="instructorDto">Expresses InstructorDto.</param>
        /// <param name="id">Expresses Instructor Id</param>
        /// <returns>True In Case UpDate Successfully, or False In Case UpDate Failed.</returns>
        Task<bool> UpDateAsync(CreateInstructorDto instructorDto, int id);

        /// <summary>
        ///     Delete Instructor By Instructor Id. 
        /// </summary>
        /// <param name="id">Expresses Instructor Id.</param>
        /// <returns>True In Case Delete Successfully, or False In Case Delete Failed.</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        ///     Check of Istructor Existed by Lambda expression 
        /// </summary>
        /// <param name="expression">Lambda expression of Iunstructor</param>
        /// <returns>True In Case Instructor Exist, or False In Case Instructor Not Exist.</returns>
        Task<bool> AnyAsync(Expression<Func<Instructor, bool>> expression);

        /// <summary>
        ///     Get InstructorID by Instructor Email.
        /// </summary>
        /// <param name="email">Expresses Instructor Email.</param>
        /// <returns>return Instructor Id type of int, or Null.</returns>
        public Task<int?> GetIdByEmailAsync(string email);
    }
}