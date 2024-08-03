using Microsoft.AspNetCore.Mvc;
using PriceQuotation.Data;
using PriceQuotation.Database;
using PriceQuotation.Models;

namespace PriceQuotation.Controllers
{
    public class QuoteController : Controller
    {
        /// <summary>
        /// This is the context for the database
        /// </summary>
        private readonly QuotationContext _context;

        /// <summary>
        /// Constructor for the QuoteController
        /// </summary>
        /// <param name="context"></param>
        public QuoteController(QuotationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This method is default when loading the page first time
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult PriceQuotation()
        {
            return View();
        }

        /// <summary>
        /// This method is loading the page when click submit on the page
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PriceQuotation(Quotation q) 
        {
            if (ModelState.IsValid) 
            {
                QuotationDB quotationDB = new QuotationDB(_context);
                // add to database
                await quotationDB.AddQuotation(q);
                // Perform any necessary calculations or operations here
                // Get the newest quotation from database
                Quotation lastQuotation = quotationDB.GetLastQuotation();
                if (lastQuotation != null) {
                    return View("PriceQuotation", lastQuotation);
                }            
            }
            return View(q);
        }
    }
}
