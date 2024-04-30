using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project_api.Context;
using Project_api.Model;
using Project_api.Repository;
using Project_api.Services;
using System.Buffers.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var ConnectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<DbProject>(options => options.UseSqlServer(ConnectionString));
builder.Services.AddControllers();

#region AppRepo

builder.Services.AddScoped<IClientsRepository,ClientsRepository> ();
builder.Services.AddScoped<IDetailInvoicesRepository, DetailInvoicesRepository>();
builder.Services.AddScoped<IGamesRepository, GamesRepository>();
builder.Services.AddScoped<IInvoicesRepository, InvoicesRepository>();
builder.Services.AddScoped<IProductionsRepository, ProductionsRepository>();
builder.Services.AddScoped<IProductTypesRepository, ProductTypesRepository>();
builder.Services.AddScoped<IStoresRepository, StoresRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

#endregion

#region AppService
builder.Services.AddScoped<IClientsService, ClientService>();
builder.Services.AddScoped< IDetailInvoicesService, DetailInvoiceService>();
builder.Services.AddScoped<IGamesService, GameService>();
builder.Services.AddScoped<IInvoicesService, InvoiceService>();
builder.Services.AddScoped<IProductionsService, ProductionService>();
builder.Services.AddScoped<IProductTypesService, ProductTypeService>();
builder.Services.AddScoped<IStoresService, StoreService>();
builder.Services.AddScoped<IUserService, UserService>();
#endregion


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
