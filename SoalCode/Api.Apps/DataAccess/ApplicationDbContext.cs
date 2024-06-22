using DataAccess.Bases;
using DataAccess.Builders;
using DataAccess.Models;
using DataAccess.SharedObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ApplicationDbContext : DbContextBase
    {
        public ApplicationDbContext(CurrentUserAccessor currentUserAccessor, DbContextOptions options) : base(currentUserAccessor, options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<BpkbTransaction> BpkbTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserEntityBuilder().Configure(modelBuilder.Entity<User>());
            new LocationEntityBuilder().Configure(modelBuilder.Entity<Location>());
            new BpkbTransactionEntityBuilder().Configure(modelBuilder.Entity<BpkbTransaction>());
        }
    }
}
