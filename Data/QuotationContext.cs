using Microsoft.EntityFrameworkCore;
using PriceQuotation.Models;

namespace PriceQuotation.Data
{
    public class QuotationContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public QuotationContext(DbContextOptions<QuotationContext> options) : base(options)
        {
        }
        
        /// <summary>
        /// Create the table quotation for database 
        /// </summary>
        public DbSet<Quotation> Quotations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quotation>()
                .Property(q => q.DiscountAmount)
                .HasComputedColumnSql("[Subtotal] * [DiscountPercent] / 100");

            modelBuilder.Entity<Quotation>()
                .Property(q => q.Total)
                .HasComputedColumnSql("[Subtotal] - ([Subtotal] * [DiscountPercent] / 100)");

            base.OnModelCreating(modelBuilder);
        }
    }
}
