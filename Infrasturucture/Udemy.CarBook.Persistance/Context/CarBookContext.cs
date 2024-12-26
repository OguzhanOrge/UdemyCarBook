using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Persistance.Context
{
	public class CarBookContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=localhost;Database=UdemyCarBookDb;TrustServerCertificate=True;integrated security = true;");
		}
		DbSet<About> Abouts { get; set;}
		DbSet<Banner> Banners { get; set;}
		DbSet<Brand> Brands { get; set;}
		DbSet<Car> Cars { get; set;}
		DbSet<CarDescription> CarsDescription { get; set;}
		DbSet<CarFeature> CarFeatures { get; set;}
		DbSet<CarPricing> CarPricings { get; set;}
		DbSet<Category> Categories { get; set;}
		DbSet<Contact> Contacts { get; set;}
		DbSet<Feature> Features { get; set;}
		DbSet<FooterAddress> FooterAddresses { get; set;}
		DbSet<Location> Locations { get; set;}
		DbSet<Pricing> Pricings { get; set;}
		DbSet<Service> Services { get; set;}
		DbSet<Author> Author { get; set;}
		DbSet<Blog> Blogs { get; set;}
		DbSet<SocialMedia> SocialMedias { get; set;}
		DbSet<Testimonial> Testimonials { get; set;}
	}
}
