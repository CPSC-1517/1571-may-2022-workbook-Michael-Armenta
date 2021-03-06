using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additonal Namespaces
using Microsoft.EntityFrameworkCore;
using WestWindSystem.Entities;
#endregion

namespace WestWindSystem.DAL
{
    //leave the access type for this class as internal
    //"internal" access to this class is ONLY possible from 
    //  within this class library project
    //Why, it adds a layer of security to the web application

    //DbContext is the entityframework software that talks to the database
    //we inherit the required class

    //Add the Nuget Package: Microsoft.EntityFrameworkCore.SqlServer
    //  required for DbContext
    internal class WestWindContext : DbContext
    {
        //the constructor will pass the context connection to the DbContext parent
        //  for use in setting up the database connection
        public WestWindContext(DbContextOptions<WestWindContext> options) : base(options)
        {

        }

        //setup properties in this class that can be referenced by other
        //  code within your class library
        //the properties represent a collection of instances of the entity
        //  retrieved from or sent to the database
        //ONE PROPERTY PER ENTITY IN ENTITIES
        //We've created the datatype DbSet<BuildVersion>
        // <BuildVersion> refers to the entity "BuildVersion" (located in the Entities folder)
        // The property name BuildVersions (plural) refers to multiple instances
        public DbSet<BuildVersion> BuildVersions { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Territory> Territories { get; set; }
    }
}
