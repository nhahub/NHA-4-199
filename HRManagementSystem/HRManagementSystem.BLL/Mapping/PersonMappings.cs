using HRManagementSystem.BLL.DTOs;
using HRManagementSystem.DAL.Entities;


namespace HRManagementSystem.BLL.Mappings;


public static class PersonMappings
{
    public static PersonDto ToDto(this Person person)
    {
        return new PersonDto
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            Email = person.Email,
            Phone = person.Phone,
            Address = person.Address,
            DateOfBirth = person.DateOfBirth,
            Gender = person.Gender.ToString()
        };
    }

    public static Person ToEntity(this CreatePersonDto dto)
    {
        return new Person
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone,
            Address = dto.Address,
            DateOfBirth = dto.DateOfBirth,
            Gender = dto.Gender
        };
    }

    
}
