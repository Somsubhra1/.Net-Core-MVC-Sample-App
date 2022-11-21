using System;
using MVCPractice.Models;

namespace MVCPractice.IRepositories
{
    public interface IDepartmentRepository
    {
        public Task<List<Department>> GetAllDepartmentsAsync();
    }
}

