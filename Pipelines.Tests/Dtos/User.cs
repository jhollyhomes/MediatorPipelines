using System.ComponentModel.DataAnnotations;

namespace Pipelines.Tests.Dtos;
public class User
{
    public User(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    [Required]
    public string FirstName { get; init; }
    [Required]
    public string LastName { get; init; }
}
