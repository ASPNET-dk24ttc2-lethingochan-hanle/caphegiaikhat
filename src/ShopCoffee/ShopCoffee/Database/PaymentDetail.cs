using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopCoffee.Database;

public partial class PaymentDetail
{
    public int? ProductId { get; set; }

    public int PaymentId { get; set; }

    [Display(Name = "Giá tiền")]
    public int? Price { get; set; }

    [Display(Name = "Số lượng")]
    public int? Quantity { get; set; }

    [Display(Name = "Tổng tiền")]
    public double? Total { get; set; }

    [Display(Name = "Ngày thanh toán")]
    public DateTime CreateAt { get; set; }

    public virtual Payment Payment { get; set; } = null!;

    public virtual Product? Product { get; set; }
}
