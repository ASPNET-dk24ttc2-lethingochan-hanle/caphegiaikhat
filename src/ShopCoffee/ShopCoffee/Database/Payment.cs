using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopCoffee.Database;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    [Display(Name = "Số điện thoại")]
    public string? Phone { get; set; }

    [Display(Name = "Email")]
    public string Email { get; set; } = null!;

    [Display(Name = "Ngày thanh toán")]
    public DateTime CreateAt { get; set; }

    [Display(Name = "Tổng tiền")]
    public double? Total { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
