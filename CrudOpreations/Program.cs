using System.Text.Json;
using CrudOpreations.Applications;
using CrudOpreations.Configurations;
var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "AllowAll";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
        });
});
// Add services to the container.

builder.Configuration.AddJsonFile("module-setting.json", optional: false, reloadOnChange: true);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration 
builder.Services
    .AddUserManagementModule<CrudSettings>()
    .AddUserDatabaseManagementModule();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();


app.MapControllers();

app.Run();
