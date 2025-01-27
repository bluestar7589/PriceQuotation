﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceQuotation.Models
{
    public class Quotation
    {
        /// <summary>
        /// The primary key of the quotation
        /// </summary>
        [Key]
        public int QuotationID { get; set; }
        /// <summary>
        /// The subtotal of the quotation
        /// </summary>
        [Required]
        [DataType(DataType.Currency)]
        public double Subtotal { get; set; }

        /// <summary>
        /// The discount percent for the quotation
        /// </summary>
        [Required]
        [Range(1,100)]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Please enter a valid number.")]
        public double DiscountPercent { get; set; }


        /// <summary>
        /// Discount amount calculate by Subtotal * DiscountPercent 
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DataType(DataType.Currency)]
        public double? DiscountAmount { get; set; }

        /// <summary>
        /// This method to get the total amount of the quotation
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DataType(DataType.Currency)]
        public double? Total { get; set; }
    }
}
