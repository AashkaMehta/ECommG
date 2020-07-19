using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class SellerDetail
    {
        public int  Id { get; set; }
        
        public string SellerName { get; set; }
       
        public string Address { get; set; }
       
        public string Pincode { get; set; }
       
        public string BusinessName { get; set; }
       
        public string City { get; set; }
       
        public string State { get; set; }
        
        public string Country { get; set; }
    }
    public class Seller
    {
       
        public string ModelNo { get; set; }
        public string ProductDescription{ get; set; }
        public int? Quantity{ get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }
    }
}
