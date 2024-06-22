﻿using DataAccess.SharedObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Bases
{
    public class DbContextBase : DbContext
    {
        private readonly CurrentUserAccessor _currentUserAccessor;

        public DbContextBase(CurrentUserAccessor currentUserAccessor, DbContextOptions options) : base(options)
        {
            _currentUserAccessor = currentUserAccessor;
        }

        public override int SaveChanges()
        {
            UpdateActorAndTimestamps();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateActorAndTimestamps();

            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateActorAndTimestamps()
        {
            var createdEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added);
            foreach (var entry in createdEntries)
            {
                if (entry.Entity is EntityBase entity)
                {
                    entity.Created = DateTime.Now;
                    entity.CreatedBy = _currentUserAccessor.Id.ToString();
                }
            }

            var modifiedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified);
            foreach (var entry in modifiedEntries)
            {
                if (entry.Entity is EntityBase entity)
                {
                    entity.Modified = DateTime.Now;
                    entity.ModifiedBy = _currentUserAccessor.Id.ToString();
                }
            }
        }
    }
}
