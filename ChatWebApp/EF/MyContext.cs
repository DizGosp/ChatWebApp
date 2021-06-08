using ChatWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWebApp.EF
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> x) : base(x)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            base.OnConfiguring(optionsBuilder);
        }



       public DbSet<Users> User { get; set; }
       public DbSet<Rooms> Room { get; set; }
       public DbSet<Messages> Message { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rooms>().HasData(
                new Rooms { RoomId = 1, Name = "Public", DateTimeCreated = DateTime.Now} 
           );
        }


        }
}
