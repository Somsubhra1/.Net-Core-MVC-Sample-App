using System;
using MVCPractice.Models;

namespace MVCPractice.IRepositories
{
    public interface IDepartmentRepository
    {
        public Task<List<Department>> GetAllDepartmentsAsync();

        public Task<int> AddDepartment(Department department);

        public Task DeleteDepartment(int departmentId);

        public Task<Department> GetDepartmentByIdAsync(int departmentId);

        public Task<int> UpdateDepartment(Department department);
    }
}

