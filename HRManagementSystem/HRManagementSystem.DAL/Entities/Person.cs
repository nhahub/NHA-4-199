using HRManagementSystem.Enums;
using HRManagementSystem.Models;
using HRManagementSystemMSConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Models;

public class Person : BaseEntity
{
    public  string FirstName { get; set; } = string.Empty;
    public  string LastName { get; set; } = string.Empty;
    public  string Email { get; set; } = string.Empty;
    public  string Phone { get; set; } = string.Empty;
    public  string Address { get; set; } = string.Empty;
    public  DateTime DateOfBirth { get; set; }
    public  Gender Gender { get; set; }

    
    public Employee? Employee { get; set; } 
    public Candidate? Candidate { get; set; }
}
