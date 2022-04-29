using HardCode.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardCode.Domain.Interfaces.IUnitsOfWork
{
    public interface IServices
    {
        /// <summary>
        ///     This Property Expresses Istructor Services.
        /// </summary>
        public IInstructorServices Instructor { get; }

        /// <summary>
        ///     This Property Expresses Department Services.
        /// </summary>
        public IDepartmentServices Department { get; }
    }
}
