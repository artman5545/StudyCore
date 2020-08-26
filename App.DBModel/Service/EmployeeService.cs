using App.BaseHelper;
using App.DBModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.DBModel.Service
{
    public interface IEmployeeService : IBaseService<Employee>
    {
    }
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        public EmployeeService(IUnitOfWork unitOfWork, IBaseRepository<Employee> currentRepository) : base(unitOfWork, currentRepository)
        {
        }
    }
}
