using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRManagementSystem.Helpers;

namespace HRManagementSystemMS01.Models
{
   
    public partial class LeaveRequest
    {
        public int TotalDays
        {
            get
            {
                var diff = (EndDate - StartDate).Days + 1;
                return diff > 0 ? diff : 0;
            }
        }

        
        partial void OnStatusChanged(string role, string status)
        {

            HRManagementSystem.Helpers.Logger.Log($"?????: {role} ??? ?????? ???? ????? ??? {status}");
        }

       
        public void UpdateStatus(string role, Enums.RequestStatus status)
        {
            OnStatusChanged(role, status.ToString());
        }
    }
}
