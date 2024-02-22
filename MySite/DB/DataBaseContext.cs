﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using MySite.Models;

namespace MySite.Infrastructure
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options ) : base( options ) 
        {
            Database.Migrate();
        }
        
    }
}
