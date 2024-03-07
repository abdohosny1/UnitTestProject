using IdealWeightCalculator.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdealWeightCalculator.Data
{
    public   class ApplicationDbContext :DbContext
    {
  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=IntegrationTestDb;User Id=sa;Password=MyComplexPwd123;");
        }
        public DbSet<User> Users { get; set; }
    }
}
