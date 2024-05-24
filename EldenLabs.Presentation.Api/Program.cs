using EldenLabs.Application.Core;
using EldenLabs.Presentation.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add injection Depencies for the other solutions
builder.Services.AddApplicationInjection(builder.Configuration);


// Configuration allow all of cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configuration Middleawre errors and logs.
app.UseMiddleware<MiddlewareContainer>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// Add policy configure in the builder
app.UseCors("AllowAll");

app.UseStatusCodePages();
app.UseAuthorization();
app.MapControllers();
app.Run();
