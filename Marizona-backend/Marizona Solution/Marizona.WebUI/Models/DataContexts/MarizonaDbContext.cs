using Marizona.WebUI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marizona.WebUI.Models.DataContexts
{
    public class MarizonaDbContext : DbContext
    {
        public MarizonaDbContext(DbContextOptions<MarizonaDbContext> options)
            :base(options)
        {

        }

        public MarizonaDbContext()
            :base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS; Initial Catalog=Marizona;User Id=sa;Password=query");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<ProductIngredient>(x => x.HasKey(aa => new { aa.ProductId, aa.IngridientId }));

            builder.Entity<ProductIngredient>()
                                             .HasOne(u => u.Product)
                                             .WithMany(a => a.Ingridients)
                                             .HasForeignKey(aa => aa.ProductId);

            builder.Entity<ProductIngredient>()
                                             .HasOne(u => u.Ingridient)
                                             .WithMany(a => a.Products)
                                             .HasForeignKey(aa => aa.IngridientId);
        }



        public DbSet<FAQ> Faqs { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogTag> BlogTags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ContactPost> ContactPosts { get; set; }
        public DbSet<Ingridient> Ingridients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductIngredient> ProductIngridients { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<PositionChef> PositionChefs { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
    }
}
