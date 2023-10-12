using DigitalAgency.Controllers;
using DigitalAgency.Models;
using DigitalAgency.Models.Categories;
using DigitalAgency.Models.Project;
using DigitalAgency.Models.Settings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DigitalAgency.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<About> Abouts { get; set; }    
        public DbSet<AboutTranslate> AboutTranslates { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<SettingTranslate> SettingsTranslates { get; set; }
        //public DbSet<Client> Clients { get; set; }
        public DbSet<Header> Headers { get; set; }
        public DbSet<HeaderTranslates> HeaderTranslates { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryTaranslate> CategoryTaranslates { get; set; }
        public DbSet<Message> Messages { get; set; }
        //public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTranslate> ProjectTranslates { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceTranslate> ServiceTranslates { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Career> Careers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<About>().HasQueryFilter(m => !m.IsDeleted);
            //modelBuilder.Entity<Client>().HasQueryFilter(m => !m.IsDeleted);
            modelBuilder.Entity<Message>().HasQueryFilter(m => !m.IsDeleted);
            //modelBuilder.Entity<Pricing>().HasQueryFilter(m => !m.IsDeleted);
            modelBuilder.Entity<Team>().HasQueryFilter(m => !m.IsDeleted);

        }



    }
}
