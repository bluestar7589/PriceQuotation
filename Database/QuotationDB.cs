using PriceQuotation.Data;
using PriceQuotation.Models;
using System.Threading.Tasks;


namespace PriceQuotation.Database
{
    public class QuotationDB
    {
        /// <summary>
        /// The context for the database
        /// </summary>
        private readonly QuotationContext _context;

        /// <summary>
        /// The constructor for the QuotationDB class
        /// </summary>
        /// <param name="context"></param>
        public QuotationDB(QuotationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This method adds a quotation to the database
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public async Task AddQuotation(Quotation q)
        {
            // Add to database
            _context.Quotations.Add(q);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get the lastest quotation from the database
        /// </summary>
        /// <returns></returns>
        public Quotation GetLastQuotation()
        {
            Quotation lastQuotation = _context.Quotations
                .OrderByDescending(q => q.QuotationID)
                .FirstOrDefault();

            return lastQuotation;
        }
    }
}
