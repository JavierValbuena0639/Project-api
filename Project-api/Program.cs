using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project_api.Context;
using Project_api.Model;
using Project_api.Repository;
using Project_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<DbProject>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("corsPolicy", policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

#region AppRepo
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IDetailInvoicesRepository, DetailInvoicesRepository>();
builder.Services.AddScoped<IGamesRepository, GamesRepository>();
builder.Services.AddScoped<IInvoicesRepository, InvoicesRepository>();
builder.Services.AddScoped<IProductionsRepository, ProductionsRepository>();
builder.Services.AddScoped<IProductTypesRepository, ProductTypesRepository>();
builder.Services.AddScoped<IStoresRepository, StoresRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
#endregion

#region AppService
builder.Services.AddScoped<IClientsService, ClientService>();
builder.Services.AddScoped<IDetailInvoicesService, DetailInvoiceService>();
builder.Services.AddScoped<IGamesService, GameService>();
builder.Services.AddScoped<IInvoicesService, InvoiceService>();
builder.Services.AddScoped<IProductionsService, ProductionService>();
builder.Services.AddScoped<IProductTypesService, ProductTypeService>();
builder.Services.AddScoped<IStoresService, StoreService>();
builder.Services.AddScoped<IProductsService, ProductService>();
builder.Services.AddScoped<IProductionsService, ProductionService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<UserService>();
#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();