using Angular7CRUDAPI.Controllers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular7CRUDAPI
{
    public class Angular7CRUDContext: DbContext
    {
        public Angular7CRUDContext(DbContextOptions<Angular7CRUDContext> options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<UserId> UserId { get; set; }

    }
}
