using System;
using Microsoft.EntityFrameworkCore;
using MyContacts.WebApi.Models;

namespace MyContacts.WebApi
{
	public class ApplicationDbContext : DbContext
	{

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

        }
		public DbSet<Contact> Contacts { get; set; }


        // use to configure primary keys, modify table name, configure foriegn keys and table relationships
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //}
    }
}

