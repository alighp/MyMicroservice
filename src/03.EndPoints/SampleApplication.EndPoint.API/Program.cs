using Microsoft.EntityFrameworkCore;
using SampleApplication.Core.ApplicationService.Categoreis;
using SampleApplication.Core.ApplicationService.Customers;
using SampleApplication.Core.ApplicationService.Customers.EventHandlers;
using SampleApplication.Core.Domain.AddressBooks;
using SampleApplication.Core.Domain.Categories;
using SampleApplication.Core.Domain.Common;
using SampleApplication.Core.Domain.Customers;
using SampleApplication.Core.Domain.Customers.Events;
using SampleApplication.Core.Domain.Orders;
using SampleApplication.Core.Domain.Products;
using SampleApplication.Framework;
using SampleApplication.Infra.Data.SQL;
using SampleApplication.Infra.Data.SQL.AddressBooks;
using SampleApplication.Infra.Data.SQL.Categories;
using SampleApplication.Infra.Data.SQL.Common;
using SampleApplication.Infra.Data.SQL.Customers;
using SampleApplication.Infra.Data.SQL.Orders;
using SampleApplication.Infra.Data.SQL.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EFDBContext>(x => x.UseSqlServer("server=. ; initial catalog = MicroService ; Trusted_connection = true"));
builder.Services.AddScoped<CustomerAppService>();
builder.Services.AddScoped<CategoryAppService>();
builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository>();
builder.Services.AddScoped<ICustomerRepository, EFCusomerRepository>();
builder.Services.AddScoped<IOrderRerpository, EFOrderRepository>();
builder.Services.AddScoped<IProductRepository, EFProductRepository>();
builder.Services.AddScoped<IAddressBookRepository, EFAddressBookRepository>();
builder.Services.AddScoped<IDomainEventHandler<CustomerCreated>, WriteCustomerCreatedToConsole>();
builder.Services.AddScoped<IDomainEventHandler<LastNameChanged>, WriteLastNameUpdatedToConsole>();
builder.Services.AddScoped<IDomainEventHandler<FirstNameChanged>, WriteFirstNameUpdatedToConsole>();
builder.Services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
builder.Services.AddScoped<IDomainUnitOfWork, EFDomainUnitOfWork>();
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
