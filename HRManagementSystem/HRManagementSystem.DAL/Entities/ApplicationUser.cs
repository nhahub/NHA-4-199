using Microsoft.AspNetCore.Identity;

namespace HRManagementSystem.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public int? EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; }
    }
}
