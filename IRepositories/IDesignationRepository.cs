using System;
using MVCPractice.Models;

namespace MVCPractice.IRepositories
{
    public interface IDesignationRepository
    {
        public Task<List<Designation>> GetAllDesignationsAsync();

        public Task<int> AddDesignation(Designation designation);

        public Task DeleteDesignation(int designationId);

        public Task<Designation> GetDesignationByIdAsync(int designationId);

        public Task<int> UpdateDesignation(Designation designation);
    }
}

