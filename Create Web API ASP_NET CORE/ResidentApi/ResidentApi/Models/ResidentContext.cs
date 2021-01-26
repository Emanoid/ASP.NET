using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ResidentApi.Models
{
    public class ResidentContext : DbContext
    {
        public ResidentContext(DbContextOptions<ResidentContext> options)
            : base(options)
        {
        }
        public DbSet<Resident> Residents { get; set; }
    }
}
