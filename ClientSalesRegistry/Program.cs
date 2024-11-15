using ClientSalesRegistry.Data;
using ClientSalesRegistry.Repositories;
using ClientSalesRegistry.Services.customerService.impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>(); 
builder.Services.AddScoped<CustomerServiceImpl>(); 

builder.Services.AddControllers(); 

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
}

app.MapControllers();

app.Run();