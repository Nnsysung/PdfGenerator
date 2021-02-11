using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PdfTest.Entities
{
   public  class Taxes
    {
        [Required(ErrorMessage = "Tax Abbr must be specified", AllowEmptyStrings = false)]
        public string TaxAbbreviation { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "The rate must be between 0.1 and infinity")]
        public double Rate { get; set; }
    }
}
