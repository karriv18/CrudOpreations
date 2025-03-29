namespace CrudOpreations.Model.Request;

public class UserRequest
{

    public required string FirstName { get; set; }
    
    public required string? MiddleName { get; set; }
    
    public required string LastName { get; set; }

    public required string BirthDay { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }
}
