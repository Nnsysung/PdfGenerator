using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PdfTest.Entities
{
   public  class Items
    {
        public string ItemName { get; set; }


        public string ItemDescription { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Item quantity must be between 1 and infinity")]


        public int ItemQuantity { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Item price must be between 1 and infinity")]
        public decimal ItemPrice { get; set; }
    }
}
