using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopCoffee.Database;

public partial class Customer
{
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "*")]
    [Display(Name = "Tên")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Họ")]
    public string? LastName { get; set; }

    [Display(Name = "Địa chỉ")]
    public string? Address { get; set; }

    [Display(Name = "Số điện thoại")]
    public string? Phone { get; set; }

    [Required(ErrorMessage = "*")]
    [Display(Name = "Email")]
    public string Email { get; set; } = null!;

    [Display(Name = "Ảnh đại diện")]
    public string? Img { get; set; }

    [Display(Name = "Ngày đăng ký")]
    public DateTime RegisteredAt { get; set; }

    [Display(Name = "Lần chỉnh sửa gần nhất")]
    public DateTime? UpdateAt { get; set; }

    [Display(Name = "Ngày sinh")]
    public DateOnly? DateOfBirth { get; set; }

    [Display(Name = "Mật khẩu")]
    [Required(ErrorMessage = "*")]
    public string? Password { get; set; }

    [Display(Name = "RandomKey")]
    public string? RandomKey { get; set; }

    [Display(Name = "Đang hoạt động")]
    public bool IsActive { get; set; }

    [Display(Name = "Phân quyền")]
    public int Role { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
