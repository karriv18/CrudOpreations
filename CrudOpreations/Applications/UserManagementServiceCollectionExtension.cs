using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using CrudOpreations.Repository;
using CrudOpreations.Services;
using CrudOpreations.Shared;
using CrudOpreations.Database;
using CrudOpreations.Configurations;
namespace CrudOpreations.Applications;

public static class UserManagementServiceCollectionExtension
{
    public static IServiceCollection AddUserManagementModule<TOptions>(this IServiceCollection services) where TOptions : class
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));

        var sectionName = typeof(TOptions).GetField(SharedConstant.SectionNamePlaceHolder)
            ?.GetRawConstantValue()
            ?.ToString();

        services.AddOptions<TOptions>()
            .BindConfiguration(sectionName!)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddScoped<IUserManagementServices, UserManagementServices>();
        services.AddScoped<IUserManagementRepository, UserManagementRepository>();

        return services;
    }
    public static IServiceCollection AddUserDatabaseManagementModule(this IServiceCollection services)
    {
        services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();
        return services;
    }
}
