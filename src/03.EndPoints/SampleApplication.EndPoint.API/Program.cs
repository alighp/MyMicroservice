using SampleApplication.Core.ApplicationService.People;
using SampleApplication.Core.ApplicationService.People.EventHandlers;
using SampleApplication.Core.Domain.People.Events;
using SampleApplication.Framework;
using SampleApplication.Infra.Data;
using SampleApplication.Infra.Data.SQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<PersonAppService>();
builder.Services.AddScoped<PersonRepository, EFPersonRepository>();
builder.Services.AddDbContext<EFDBContext>();
builder.Services.AddTransient<IDomainEventHandler<PersonCreated>, WritePersonCreatedToConsole>();
builder.Services.AddTransient<IDomainEventDispatcher, DomainEventDispatcher>();
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
