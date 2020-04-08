using GazaEmgCore2.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GazaEmgCore2.Data
{
    public class ApplicationContext:IdentityDbContext<User>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "GazaEmgCore",
                IntegratedSecurity = true


            };
            optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ToString());
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<MapSetting> MapSettings { get; set; }
        public DbSet<ArrivingPoint> ArrivingPoints { get; set; }
        public DbSet<ArrivingPointDetail> ArrivingPointDetails { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Governorate> Governorates { get; set; }
         public DbSet<HealthCenter> HealthCenters { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<QuarantinedPerson> QuarantinedPerson { get; set; }
        public DbSet<Logs> Logs { get; set; }


        #region save changes methods

        public int SaveChanges(string userId)
        {
            // Get all Added/Deleted/Modified entities (not Unmodified or Detached)
            foreach (var ent in this.ChangeTracker.Entries().Where(p => p.State == EntityState.Added || p.State == EntityState.Deleted || p.State == EntityState.Modified).ToList())
            {
                var logs = GetAuditRecordsForChange(ent, userId).ToList();

                if (logs.Count > 0)
                    this.Logs.AddRange(logs);
            }

            // Call the original SaveChanges(), which will save both the changes made and the audit records
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(string userId)
        {
            // Get all Added/Deleted/Modified entities (not Unmodified or Detached)
            foreach (var ent in this.ChangeTracker.Entries().Where(p => p.State == EntityState.Added || p.State == EntityState.Deleted || p.State == EntityState.Modified).ToList())
            {
                var logs = GetAuditRecordsForChange(ent, userId).ToList();

                if (logs.Count > 0)
                    this.Logs.AddRange(logs);
            }

            // Call the original SaveChanges(), which will save both the changes made and the audit records
            return await base.SaveChangesAsync();
        }

        private static List<Logs> GetAuditRecordsForChange(EntityEntry dbEntry, string userId)
        {
            var result = new List<Logs>();

            var changeTime = DateTime.Now;

            // Get the Table() attribute, if one exists
            var tableAttr = dbEntry.Entity.GetType().GetCustomAttributes(typeof(TableAttribute), false).SingleOrDefault() as TableAttribute;

            // Get table name (if it has a Table attribute, use that, otherwise get the pluralized name)
            var tableName = tableAttr != null ? tableAttr.Name : dbEntry.Entity.GetType().Name;

            // Get primary key value (If you have more than one key column, this will need to be adjusted)
            var keyName = dbEntry.CurrentValues.Properties.FirstOrDefault(c => c.IsPrimaryKey()).Name;

            if (dbEntry.State == EntityState.Added)
            {
                // For Inserts, just add the whole record
                // If the entity implements IDescribableEntity, use the description from Describe(), otherwise use ToString()
                result.Add(new Logs
                {
                    EventType = "A", // Added
                    TableName = tableName,
                    RecordId = Convert.ToInt32(dbEntry.CurrentValues[keyName].ToString()), // Again, adjust this if you have a multi-column key
                    ColumnName = "*ALL",
                    NewValue = JsonConvert.SerializeObject(dbEntry.CurrentValues.ToObject()),
                    InsertUser = userId,
                    InsertDate = changeTime,
                    CreatedBy = userId

                });
            }
            else if (dbEntry.State == EntityState.Deleted)
            {
                // Same with deletes, do the whole record, and use either the description from Describe() or ToString()
                result.Add(new Logs
                {
                    EventType = "D", // Deleted
                    TableName = tableName,
                    RecordId = Convert.ToInt32(dbEntry.CurrentValues[keyName].ToString()),
                    ColumnName = "*ALL",
                    NewValue = JsonConvert.SerializeObject(dbEntry.CurrentValues.ToObject()),
                    InsertUser = userId,
                    InsertDate = changeTime,
                    CreatedBy = userId
                });
            }
            else if (dbEntry.State == EntityState.Modified)
            {
                foreach (Property property in dbEntry.OriginalValues.Properties)
                {
                    // For updates, we only want to capture the columns that actually changed
                    if (!object.Equals(dbEntry.OriginalValues[property.Name], dbEntry.CurrentValues[property.Name]))
                    {
                        result.Add(new Logs
                        {
                            EventType = "M",    // Modified
                            TableName = tableName,
                            RecordId = Convert.ToInt32(dbEntry.CurrentValues[keyName].ToString()),
                            ColumnName = property.Name,
                            OriginalValue = dbEntry.OriginalValues[property.Name]?.ToString(),
                            NewValue = dbEntry.CurrentValues[property.Name]?.ToString(),
                            InsertUser = userId,
                            InsertDate = changeTime,
                            CreatedBy = userId
                        });
                    }
                }
            }
            // Otherwise, don't do anything, we don't care about Unchanged or Detached entities

            return result;
        }

        #endregion
    }
}
