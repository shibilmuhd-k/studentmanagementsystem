using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using school.dashboard.Model;

namespace school.dashboard.DBContext
{
    public class SQLContext : DbContext
    {
        public SQLContext(DbContextOptions<SQLContext> options) : base(options)
        {
        }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = "1",
                    roleId = "1",
                    firstName = "test name 1",
                    lastName = " test std 1",
                    address = "",
                    phoneNumber = "",
                    regID = "",
                    std="",
                    sec = "",
                    image = ""
                }
            );
            modelBuilder.Entity<Staff>().HasData(
                new Staff
                {
                    Id = "1",
                    roleId = "1",
                    firstName = "test name 1",
                    lastName = " test std 1",
                    address = "",
                    phoneNumber = "",
                    staffID = "",
                    email = "",
                    image = ""
                }
            );
            modelBuilder.Entity<Roles>().HasNoKey().HasData(
                new Roles
                {
                    roleId = "1",
                    role = "test roles 1",
                }
            );
            modelBuilder.Entity<Subject>().HasData(
              new Subject
              {
                  Id = "1",
                  subId = "1",
                  subject = "test subject 1",
              }
          );
        }



    }
}


