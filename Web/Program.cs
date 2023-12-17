
using Application;
using Infrastructure;
using Infrastructure.Seed;
using Presentation;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSwaggerGen();

ConfigurationManager configuration = builder.Configuration;
builder.Services
    .AddApplication()
    .AddPresentation()
    .AddInfrastructure(configuration);

builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    await dataSeeder.Seed();
}

if(app.Environment.IsDevelopment())
{ 
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAntiforgery();
app.UseHttpsRedirection();
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();
app.AddEndPoint();
app.Run();


