using System;
using MVCPractice.Models;

namespace MVCPractice.IRepositories
{
    public interface IDesignationRepository
    {
        public Task<List<Designation>> GetAllDesignationsAsync();
    }
}

