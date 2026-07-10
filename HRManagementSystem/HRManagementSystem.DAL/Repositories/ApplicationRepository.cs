using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRManagementSystem.DAL.Context;
using HRManagementSystem.DAL.Entities;
using HRManagementSystem.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.DAL.Repositories;

public class ApplicationRepository
    : GenericRepository<Application>, IApplicationRepository
{
    public ApplicationRepository(HRDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<Application>> GetAllWithDetailsAsync()
    {
        return await _context.Applications

            .Include(a => a.Candidate)
                .ThenInclude(c => c.Person)

            .Include(a => a.JobRequisition)

            .ToListAsync();
    }

    public async Task<Application?> GetByIdWithDetailsAsync(int id)
    {
        return await _context.Applications

            .Include(a => a.Candidate)
                .ThenInclude(c => c.Person)

            .Include(a => a.JobRequisition)

            .FirstOrDefaultAsync(a => a.Id == id);
    }
}
