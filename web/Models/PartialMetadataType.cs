using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace web.Models
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
        public int Id { get; internal set; }
    }
    public partial class Category
    {
        [NotMapped]

        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
    }
    public partial class Brand
    {
        [NotMapped]

        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
    }

    //[MetadataType(typeof(CategoryMasterData))]
    //public partial class Category_2119110143
    //{
    //    [NotMapped]
    //    public System.Web.HttpPostedFileBase ImageUpload { get; set; }
    //}
}