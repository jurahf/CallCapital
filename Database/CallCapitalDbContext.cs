using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class CallCapitalDbContext : DbContext
    {
        public CallCapitalDbContext(
            DbContextOptions<CallCapitalDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserResults> UserResults { get; set; }
    }
}
