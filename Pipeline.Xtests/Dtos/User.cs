using System.ComponentModel.DataAnnotations;

namespace Pipeline.Xtests.Dtos;
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
