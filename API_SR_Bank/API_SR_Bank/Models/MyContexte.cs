using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_SR_Bank.Models
{
    public class MyContexte : DbContext
    {
        public MyContexte(DbContextOptions<MyContexte> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Action> cctions { get; set; }
    }
}
