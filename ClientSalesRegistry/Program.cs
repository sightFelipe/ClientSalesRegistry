using ClientSalesRegistry.Data;
using ClientSalesRegistry.Repositories.CustomerRepository;
using ClientSalesRegistry.Repositories.ProductRepository;
using ClientSalesRegistry.Services.customerService.impl;
using ClientSalesRegistry.Services.ProductService;
using ClientSalesRegistry.Services.ProductService.Impl;
using ClientSalesRegistry.Services.SaleService; 
using ClientSalesRegistry.Services.SaleService.Impl; 
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<CustomerServiceImpl>();
builder.Services.AddScoped<IProductRepository, ProductRepositoryImpl>();
builder.Services.AddScoped<IProductService, ProductServiceImpl>();


builder.Services.AddScoped<ISaleService, SaleServiceImpl>(); 

builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
}

app.MapControllers();

app.Run();