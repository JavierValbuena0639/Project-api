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
        public DbSet<Clients> clients {  get; set; }
        public DbSet<DetailInvoices> detailInvoices { get; set; }
        public DbSet<Games> games { get; set; }
        public DbSet<Invoices> invoices {  get; set; }
        public DbSet<Products> products {  get; set; }
        public DbSet<Productions> productions {  get; set; }
        public DbSet<ProductTypes> productTypes {  get; set; }
        public DbSet<Stores> stores {  get; set; }
        public DbSet<Users> users {  get; set; }

    }
}
