using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PdfTest.Entities
{
   public  class Invoice
    {
        public int InvoiceNumber { get; set; }


        [Required(ErrorMessage = "Invoice date must be specified"), DataType(DataType.DateTime)]
        public DateTime InvoiceDate { get; set; }

        public string PurchaseOrderNumber { get; set; }

        [Required(ErrorMessage = "Invoice due date must be specified"), DataType(DataType.DateTime)]
        public DateTime InvoiceDueDate { get; set; }
    }
}
