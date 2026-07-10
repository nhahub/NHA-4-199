using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRManagementSystem.DAL.Entities;

namespace HRManagementSystem.DAL.Repositories.Interfaces;

public interface ICandidateRepository : IGenericRepository<Candidate>
{
    Task<IEnumerable<Candidate>> GetAllWithPersonAsync();

    Task<Candidate?> GetByIdWithPersonAsync(int id);
}
