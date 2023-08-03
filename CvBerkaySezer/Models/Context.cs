using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CvBerkaySezer.Models
{
    public class Context : DbContext
    {
        public DbSet<Title> Titles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ServiceProvider> ServiceProviders { get; set; }
        public DbSet<Hosting> Hostings { get; set; }
        public DbSet<Domain> Domains { get; set; }
    }
}