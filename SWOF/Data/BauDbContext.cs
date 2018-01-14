using Microsoft.EntityFrameworkCore;
using SWOF.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWOF.Data
{
    public class BauDbContext : DbContext
    {
        /// <param name="options">Database context options</param>
        public BauDbContext(DbContextOptions<BauDbContext> options)
            : base(options)
        {

        }

        public DbSet<Engineer> Engineer { get; set; }
    }
}
