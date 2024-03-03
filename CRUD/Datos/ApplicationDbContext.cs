using CRUD.Models;
using Microsoft.EntityFrameworkCore;
namespace CRUD.Datos
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
		{ 
		}

		public DbSet<Producto> Productos { get; set; }
		public DbSet<Brand> Brands { get; set; }

		public DbSet<Category> Categories { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Producto>()
				.HasOne(p => p.Brand)
				.WithMany()
				.HasForeignKey(p => p.BrandId);

			builder.Entity<Producto>()
				.HasOne(p => p.Category)
				.WithMany()
				.HasForeignKey(p => p.CategoryId);

			base.OnModelCreating(builder);
		}
	}
}
