using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PdfTest.Entities
{
  public  class Customer
    {
        [Required(ErrorMessage = "Customer Name must be specified", AllowEmptyStrings = false)]
        public string CustomerName { get; set; }


        [Required(ErrorMessage = "Customer Address must be specified", AllowEmptyStrings = false)]
        public string CustomerAddress { get; set; }


        [Required(ErrorMessage = "Customer Mail must be specified", AllowEmptyStrings = false), DataType(DataType.EmailAddress)]
        public string CustomerMail { get; set; }
    }
}
