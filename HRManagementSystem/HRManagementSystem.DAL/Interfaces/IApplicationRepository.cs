using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRManagementSystem.DAL.Entities;

namespace HRManagementSystem.DAL.Repositories.Interfaces;

public interface IApplicationRepository : IGenericRepository<Application>
{
    Task<IEnumerable<Application>> GetAllWithDetailsAsync();

    Task<Application?> GetByIdWithDetailsAsync(int id);
}
