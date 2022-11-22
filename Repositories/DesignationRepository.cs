using System;
using Microsoft.EntityFrameworkCore;
using MVCPractice.IRepositories;
using MVCPractice.Models;

namespace MVCPractice.Repositories
{
    public class DesignationRepository : IDesignationRepository
    {
        private readonly DbConnectionContext _context;

        public DesignationRepository(DbConnectionContext context)
        {
            _context = context;
        }

        public async Task<List<Designation>> GetAllDesignationsAsync()
        {
            var a = await _context.Designations.Where(desi => desi.IsActive == true).ToListAsync();

            return a;
        }
    }
}

