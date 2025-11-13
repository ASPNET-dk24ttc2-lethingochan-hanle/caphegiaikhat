using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ShopCoffee.Attributes
{
    public class RoleAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _role;

        public RoleAttribute(string role)
        {
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var session = context.HttpContext.Session;
            var userRole = session.GetString("Role");

            if (string.IsNullOrEmpty(userRole) || userRole != _role)
            {
                // Nếu không có quyền, chuyển về trang đăng nhập
                context.Result = new RedirectToActionResult("Login", "Customer", new { area = "" });
            }
        }
    }
}
