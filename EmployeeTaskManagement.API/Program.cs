using EmployeeTaskManagement.API.Handlers;
using EmployeeTaskManagement.Business;
using EmployeeTaskManagement.Core;
using EmployeeTaskManagement.Core.Utilities.Security.Encyption;
using EmployeeTaskManagement.Core.Utilities.Security.Jwt;
using EmployeeTaskManagement.DataAccess;
using EmployeeTaskManagement.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

EmployeeTaskManagementContext.ConnectionString =
    builder.Configuration.GetConnectionString("EmployeeTaskManagementContext")
    ?? throw new InvalidOperationException("'EmployeeTaskManagementContext' connection string not found.");

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>()
    ?? throw new InvalidOperationException("'TokenOptions' section not found.");

// Add services to the container.

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddCoreServices();
builder.Services.AddDataAccessServices();
builder.Services.AddBusinessServices();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options => {
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Sadece Token, 'Bearer' öneki otomatik eklenir."
        });

        options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
        {
            [new OpenApiSecuritySchemeReference("Bearer", document)] = []
        });
    }
);

builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
