using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using web.Models;
namespace web.Context
{
    [MetadataType(typeof(UserMasterData))]
    public partial class User
    {
       

    }
    [MetadataType(typeof(ProductMasterData))]
    public partial class Product
    {
        [NotMapped]

        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
      
    }
    [MetadataType(typeof(CategoryMasterData))]
    public partial class Category
    {
        [NotMapped]

        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
    }
    [MetadataType(typeof(BrandMasterData))]
    public partial class Brand
    {
        [NotMapped]

        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
    }


}