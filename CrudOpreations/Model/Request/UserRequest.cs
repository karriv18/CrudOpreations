using System.Text.Json.Serialization;
namespace CrudOpreations.Model.Request;

public class UserRequest
{
    [JsonPropertyName("firstName")]
    public required string FirstName { get; init; }

    [JsonPropertyName("middleName")]
    public required string? MiddleName { get; init; }

    [JsonPropertyName("lastName")]
    public required string LastName { get; init; }

    [JsonPropertyName("birthDay")]
    public required string BirthDay { get; init; }

    [JsonPropertyName("email")]
    public required string Email { get; init; }

    [JsonPropertyName("password")]
    public required string Password { get; init; }
}
