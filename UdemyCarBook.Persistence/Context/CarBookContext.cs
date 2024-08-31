using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Persistence.Context
{
    public class CarBookContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = DESKTOP-TOGRPIE\\SQLEXPRESS; initial catalog = UdemyCarBookDb; integrated security = true; trustServerCertificate = true;  ");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarDescription> CarDescriptions { get; set; }
        public DbSet<CarPricing> CarPricings { get; set; }
        public DbSet<CarFeature> CarFeatures { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FooterAddress> FooterAddresses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SocailMedia> SocailMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Author> Authors  { get; set; }
        public DbSet<TagCloud> TagClouds  { get; set; }
        public DbSet<Comment> Comments  { get; set; }
        public DbSet<RentACar> RentACars  { get; set; }
        public DbSet<RentACarProcess> RentACarProcesses  { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review>  Reviews { get; set; }
        public DbSet<AppUser>  AppUsers { get; set; }
        public DbSet<AppRole>  AppRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>().HasOne(x =>x.PickUpLocation).WithMany(t=>t.PickUpReservation).HasForeignKey(z=>z.PickupLocationId).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Reservation>().HasOne(t => t.DropOffLocation).WithMany(y => y.DropOffReservation).HasForeignKey(k => k.DropOffLocationId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
    
}
