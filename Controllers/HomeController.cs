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
            //Quotation q = new Quotation();
            return View();
        }

        [HttpPost]
        public IActionResult PriceQuotation(Quotation q) 
        {
            if (ModelState.IsValid) 
            {
                // add to database
                //_context.Quotations.Add(q);
                //_context.SaveChanges();
                // Perform any necessary calculations or operations here
                q.DiscountAmount = q.Subtotal * q.DiscountPercent / 100;
                q.Total = q.Subtotal - q.DiscountAmount;
                return View("PriceQuotation", q);
            }
            return View(q);
        }
    }
}
