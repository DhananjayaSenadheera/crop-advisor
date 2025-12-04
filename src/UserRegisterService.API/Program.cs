using Microsoft.AspNetCore.Diagnostics;
using UserRegisterService.API.Middleware;
using UserRegisterService.Application.Dependency_Injection;
using UserRegisterService.Insfractrucure.Dependency_injection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.InjectInfLayer(builder.Configuration);
builder.Services.InjectAppLayer();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Authentication API v1");
        c.RoutePrefix = string.Empty; // Root path
    });
    
}
app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<GlobalExceptionMiddleware>();
//app.UseHttpsRedirection();
app.MapControllers();
app.Run();
