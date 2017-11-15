using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using trainCrew.Models;
using  trainCrew.Models.Train;


namespace trainCrew.DAL
{
    public class TrainContext:DbContext
    {
        public TrainContext() : base("TrainBaseData")//the connection string 
        {
        }

        public DbSet<SystemUser> SystemUsers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
       public DbSet<DriverGroup> DriverGroups { get; set; }
       public DbSet<DriverTeam> DriverTeams { get; set; }

       public DbSet<Station> Stations { get; set; }

       public DbSet<Trip>Trips { get; set; }

       public DbSet<GeneralConfig> GeneralConfigs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//prevents table names from being pluralized
           // modelBuilder.Conventions.Remove<IncludeMetadataConvention>();//防止黑幕交易 要不然每次都要访问
        }

    }
}