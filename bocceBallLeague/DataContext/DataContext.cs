using bocceBallLeague.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bocceBallLeague.Context
{
    class DataContext :DbContext
    {
        public DataContext() : base("name=DefaultConnection")
    {

    }

        public DbSet<Games> Games { get; set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Players> Players { get; set; }

    }
}
   