using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopCoffee.Database;
using ShopCoffee.Helper;
using ShopCoffee.Models;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ShopCoffee.Controllers
{
    public class CartController : Controller
    {
        private readonly ShopCoffeeContext _context;
        public CartController(ShopCoffeeContext context)
        {
            _context = context;
        }

        public List<CartItem> Cart => HttpContext.Session.Get<List<CartItem>>(MyConst.CART_KEY) ??
            new List<CartItem>();

        public IActionResult Index()
        {
            return View(Cart);
        }
        public async Task<IActionResult> AddToCart(int id, int quantity = 1)
        {
            var gioHang = Cart;
            var item = gioHang.SingleOrDefault(p => p.IdProduct == id);
            if (item == null)
            {
                Product? productById = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);

                if (productById == null)
                {
                    TempData["Message"] = "Khong tim thay san pham";
                    return Redirect("/404");
                }

                item = new CartItem
                {
                    IdProduct = productById.ProductId,
                    Img = productById.Img ?? "",
                    Name = productById.Title,
                    Price = productById.Price,
                    Quantity = quantity
                };
                gioHang.Add(item);
            }
            else
            {
                item.Quantity += quantity;
            }

            HttpContext.Session.Set(MyConst.CART_KEY, gioHang);

            return RedirectToAction("Index");
        }
        public IActionResult ChangeQuantityCart(int id, bool isIncrement = true, int quantity = 1)
        {
            // Lấy toàn bộ giỏ hàng 
            var gioHang = Cart;
            var item = gioHang.SingleOrDefault(p => p.IdProduct == id);

            //kiểm tra tồn tại Product 
            if (item == null)
            {

                TempData["Message"] = "Khong tim thay san pham";
                return Redirect("/404");
            }
            else
            {
                // Nếu là button tăng số lượng 
                if (isIncrement)
                {
                    item.Quantity += quantity;
                }
                // Nếu là button giảm số lượng 
                else
                {
                    item.Quantity -= quantity;
                    // Nếu khách hàng nhập số lượng <= 0 thì xóa sản phẩm đó ra khỏi giỏ
                    if (item.Quantity <= 0)
                    {
                        gioHang.Remove(item);
                    }
                }
            }

            // Lưu thay đổi 
            HttpContext.Session.Set(MyConst.CART_KEY, gioHang);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveCart(int id)
        {
            var gioHang = Cart;

            var item = gioHang.SingleOrDefault(p => p.IdProduct == id);
            if (item != null)
            {
                gioHang.Remove(item);
                HttpContext.Session.Set(MyConst.CART_KEY, gioHang);
            }
            return RedirectToAction("Index");
        }
    }
}
