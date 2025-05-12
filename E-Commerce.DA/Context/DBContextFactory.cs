using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;

namespace E_Commerce.DA.Context
{
        public class DBContextFactory : IDesignTimeDbContextFactory<DBContext>
        {
            public DBContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<DBContext>();
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=E-Commerce;Integrated Security=True;Trust Server Certificate=True;");
    
                return new DBContext(optionsBuilder.Options );
            }
        }
    }

