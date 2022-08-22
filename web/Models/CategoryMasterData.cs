using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class CategoryMasterData
    {
        public int Id { get; set; }
        [Display(Name = "Tên loại sản phẩm")]
        [Required(ErrorMessage = "Tên loại sản phẩm không được để trống")]

        public string Name { get; set; }
        [Display(Name = "Hình ảnh")]
       

        public string Avatar { get; set; }
        [Display(Name = "Độ phổ biến")]
        public Nullable<int> IsPopular { get; set; }

        public string Slug { get; set; }
        [Display(Name = "Hiển thị lên trang chủ")]
        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<bool> Deleted { get; set; }
        [Display(Name = "Ngày tạo")]
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        [Display(Name = "Ngày cập nhật")]
        public Nullable<System.DateTime> UpdatedOnUtc { get; set; }


    }
}