using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web.Models
{
    public partial class ProductMasterData
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
       
        [Required]
        public string Avatar { get; set; }

        [Required]
        public Nullable<int> CategoryId { get; set; }

        public Nullable<int> TypeId { get; set; }
        [Required]
   
        public Nullable<int> BrandId { get; set; }
        [Required]
       
        public string ShortDes { get; set; }
        [Required]
      
        public string FullDescription { get; set; }
        [Required]
       
        public Nullable<double> Price { get; set; }
    
        [Required]

        public Nullable<double> PriceDiscount { get; set; }
        public string Slug { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        public Nullable<System.DateTime> UpdatedOnUtc { get; set; }
    }
}