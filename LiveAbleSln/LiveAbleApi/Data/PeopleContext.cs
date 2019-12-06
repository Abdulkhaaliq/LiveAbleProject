using LiveAbleApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveAbleApi.Data
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions<PeopleContext> options)
            : base(options)
        {
        }

        public DbSet<People> UsersInfo { get; set; }
    }
}
