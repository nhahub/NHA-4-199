using HRManagementSystem.Models;
using HRManagementSystemMS01.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystemMS01.Models
{
    public partial class LeaveRequest : BaseEntity
    {
        public int EmployeeId { get; set; }
        public LeaveType Type { get; set; }
        public string? OtherTypeDescription { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        
        public RequestStatus ManagerStatus { get; set; } = RequestStatus.Pending;
        public RequestStatus HrStatus { get; set; } = RequestStatus.Pending;

        public string? Comment { get; set; } = string.Empty;

        //Navigation Properties

        public required Employee Employee { get; set; }

        partial void OnStatusChanged(string role, string status);


        public override bool Equals(object? obj)
        {
            if (obj is LeaveRequest other)
            {
                return this.Id == other.Id && this.EmployeeId == other.EmployeeId;
            }
            return false;
        }

        // GetHashCode  Collections
        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ EmployeeId.GetHashCode();
        }
    }

}



