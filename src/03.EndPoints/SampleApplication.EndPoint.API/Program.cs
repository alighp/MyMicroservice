using Microsoft.EntityFrameworkCore;
using SampleApplication.Core.ApplicationService.Customers;
using SampleApplication.Core.ApplicationService.Customers.EventHandlers;
using SampleApplication.Core.Domain.Customers.Events;
using SampleApplication.Framework;
using SampleApplication.Infra.Data;
using SampleApplication.Infra.Data.SQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EFDBContext>(x => x.UseSqlServer("server=. ; initial catalog = MicroService ; Trusted_connection = true"));
builder.Services.AddTransient<CustomerAppService>();
builder.Services.AddTransient<CustomerRepository, EFPersonRepository>();
builder.Services.AddTransient<IDomainEventHandler<CustomerCreated>, WriteCustomerCreatedToConsole>();
builder.Services.AddTransient<IDomainEventHandler<LastNameChanged>, WriteLastNameUpdatedToConsole>();
builder.Services.AddTransient<IDomainEventHandler<FirstNameChanged>, WriteFirstNameUpdatedToConsole>();
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
