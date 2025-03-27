namespace CrudOpreations.Model.Response;

public class PeopleResponse
{
    public required int Id { get; set; }

    public required string FirstName { get; set; }

    public required string? MiddleName { get; set; }

    public required string LastName { get; set; }

    public required string BirthDay { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }
}
