namespace CrudOpreations.Routing;

public static class ApiRoute
{
    private const string ModuleBaseRoute = "api/v1/user-management";

    private const string Base = $"/{ModuleBaseRoute}/users";

    public const string GetAll = Base;

    public const string Create = $"{Base}/user-form";
   
    public const string Get = $"{Base}/get-user/{{id}}";

    public const string Update = $"{Base}/user-update-form";
    
    public const string Delete = $"{Base}/delete-user/{{id}}";



}
