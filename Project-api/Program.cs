using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project_api.Context;
using Project_api.Model;
using Project_api.Services;
using System.Buffers.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var ConnectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<DbProject>(options => options.UseSqlServer(ConnectionString));
builder.Services.AddControllers();

#region AppRepo

builder.Services.AddScoped<IClientsRepository, ClientService> ();
builder.Services.AddScoped<IDetailInvoicesRepository, DetailInvoiceService>();
builder.Services.AddScoped<IGamesRepository, GameService>();
builder.Services.AddScoped<IInvoicesRepository, InvoiceService>();
builder.Services.AddScoped<IProductionsRepository, ProductionService>();
builder.Services.AddScoped<IProductTypesRepository, ProductTypeService>();
builder.Services.AddScoped<IStoresRepository, StoreService>();
builder.Services.AddScoped<IUsersRepository, UserService>();

#endregion

#region AppService
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<DetailInvoiceService>();
builder.Services.AddScoped<GameService>();
builder.Services.AddScoped<InvoiceService>();
builder.Services.AddScoped<ProductionService>();
builder.Services.AddScoped<ProductTypeService>();
builder.Services.AddScoped<StoreService>();
builder.Services.AddScoped<UserService>();
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
