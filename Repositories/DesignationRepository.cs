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
            return await _context.Designations.Where(desi => desi.IsActive == true).ToListAsync();
        }

        public async Task<int> AddDesignation(Designation designation)
        {
            designation.ModifiedDate = DateTime.Now;
            designation.IsActive = true;
            _context.Designations.Add(designation);
            await _context.SaveChangesAsync();
            return designation.DesignationId;
        }

        public async Task DeleteDesignation(int designationId)
        {
            var designation = await _context.Designations.Where(desi => desi.DesignationId == designationId).FirstAsync();
            designation.IsActive = false;
            designation.ModifiedDate = DateTime.Now;
            _context.Designations.Update(designation);
            await _context.SaveChangesAsync();
        }

        public async Task<Designation> GetDesignationByIdAsync(int designationId)
        {
            var designation = await _context.Designations.Where(desi => desi.DesignationId == designationId).FirstOrDefaultAsync();

            return designation;
        }

        public async Task<int> UpdateDesignation(Designation designation)
        {
            designation.ModifiedDate = DateTime.Now;
            designation.IsActive = true;
            _context.Designations.Update(designation);
            await _context.SaveChangesAsync();

            return designation.DesignationId;
        }
    }
}

