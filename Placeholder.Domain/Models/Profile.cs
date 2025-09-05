namespace Placeholder.Domain.Models;

public class Profile
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Dob { get; set; }

    public override string ToString()
    {
        return $"Id={Id}, FirstName={FirstName}";
    }
}