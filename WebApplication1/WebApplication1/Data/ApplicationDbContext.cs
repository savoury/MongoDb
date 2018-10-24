using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using WebApplication1.Service;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
            //: base(options)
        {
            var client = new MongoClient();
        }

        public DbSet<Product> Products { get; set; }
    }
}
