
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web.Context;

namespace Web.Models
{
    public class HomeModel
    {
        public List<Brand> ListBrands { get; set; }
        public List<Product> ListProduct { get; set; }
        public List<Category> ListCategory { get; set; }

    }
}