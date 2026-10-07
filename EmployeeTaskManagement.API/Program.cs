using EmployeeTaskManagement.DataAccess.Concrete.EntityFramework.Contexts;

var builder = WebApplication.CreateBuilder(args);

EmployeeTaskManagementContext.ConnectionString =
    builder.Configuration.GetConnectionString("EmployeeTaskManagementContext")
    ?? throw new InvalidOperationException("'EmployeeTaskManagementContext' connection string not found.");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
