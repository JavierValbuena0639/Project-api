using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Project_api.Model;

namespace Project_api.Context
{
    public class DbProject : DbContext
    {
        public DbProject(DbContextOptions<DbProject> options) : base(options) 
            { 

            }
    public DbSet<Users> users {  get; set; }
    public DbSet<Store> corps { get; set; }
    public DbSet<Clients> levels {  get; set; }
    public DbSet<Trades> trades {  get; set; }
    public DbSet<ProductType> matchs {  get; set; }
    public DbSet<Product> items {  get; set; }
    public DbSet<Enemys> enemys {  get; set; }

    }
}
