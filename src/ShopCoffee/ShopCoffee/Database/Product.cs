using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopCoffee.Database;

public partial class Product
{
    public int ProductId { get; set; }

    [Required(ErrorMessage = "*")]
    [Display(Name = "Tên đồ uống")]
    public string Title { get; set; } = null!;

    [Display(Name = "Mô tả")]
    public string? Content { get; set; }

    [Display(Name = "Ảnh")]
    public string? Img { get; set; }

    [Required(ErrorMessage = "*")]
    [Display(Name = "Giá")]
    public long Price { get; set; }

    [Display(Name = "Ngày tạo")]
    public DateTime? CreateAt { get; set; }

    [Display(Name = "Lần chỉnh sửa gần nhất")]
    public DateTime? UpdateAt { get; set; }

    [Required(ErrorMessage = "*")]
    [Display(Name = "Danh mục")]
    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
}
