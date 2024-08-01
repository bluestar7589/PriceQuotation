using Microsoft.AspNetCore.Mvc;
using PriceQuotation.Data;
using PriceQuotation.Models;

namespace PriceQuotation.Controllers
{
    public class HomeController : Controller
    {

        /// <summary>
        /// The context for the database
        /// </summary>
        private readonly QuotationContext _context;

        public HomeController(QuotationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult PriceQuotation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PriceQuotation(Quotation q) 
        {
            if (ModelState.IsValid) 
            {
                // add to database
                /*                _context.Quotations.Add(q);
                                await _context.SaveChangesAsync();

                                Quotation quotation = await _context.Quotations.FindAsync(q.QuotationID);
                                return View("PriceQuotation", quotation);*/
                // Perform any necessary calculations or operations here
                q.DiscountAmount = q.Subtotal * q.DiscountPercent / 100;
                q.Total = q.Subtotal - q.DiscountAmount;
                return View(q);
            }
            return View(q);
        }
    }
}
