using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_RNWA.Models
{
    public class CrudProp
    {
        public string productCode { get; set; }
        public string productName { get; set; }
        public string productLine { get; set; }
        public string productScale { get; set; }
        public string productVendor { get; set; }
        public string productDescription { get; set; }
        public int quantityInStock { get; set; }
        public decimal buyPrice { get; set; }
        public decimal MSRP { get; set; }



    }
}