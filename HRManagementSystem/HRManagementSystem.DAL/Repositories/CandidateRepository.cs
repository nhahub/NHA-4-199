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

public class CandidateRepository
    : GenericRepository<Candidate>, ICandidateRepository
{
    public CandidateRepository(HRDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<Candidate>> GetAllWithPersonAsync()
    {
        return await _context.Candidates
            .Include(c => c.Person)
            .ToListAsync();
    }

    public async Task<Candidate?> GetByIdWithPersonAsync(int id)
    {
        return await _context.Candidates
            .Include(c => c.Person)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}
