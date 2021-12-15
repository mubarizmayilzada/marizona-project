using Marizona.WebUI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marizona.WebUI.Models.DataContexts
{
    public class MarizonaDbContext : DbContext
    {
        public MarizonaDbContext(DbContextOptions<MarizonaDbContext> options)
            :base(options)
        {

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
    }
}
