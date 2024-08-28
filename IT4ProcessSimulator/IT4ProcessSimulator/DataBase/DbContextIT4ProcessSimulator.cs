using IT4ProcessSimulator.Models;
using Microsoft.EntityFrameworkCore;

namespace IT4ProcessSimulator.DataBase
{
    public class DbContextIT4ProcessSimulator : DbContext
    {
        public DbContextIT4ProcessSimulator(DbContextOptions<DbContextIT4ProcessSimulator> options) : base(options)
        {          
        }

        public DbSet<CompanyModel> Company { get; set; }

    }
}
