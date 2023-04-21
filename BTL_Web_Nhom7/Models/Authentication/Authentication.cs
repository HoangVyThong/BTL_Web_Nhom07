using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BTL_Web_Nhom7.Models.Authentication
{
    public class Authentication : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.HttpContext.Session.GetString("TenTaiKhoan") == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "Controller", "Admin" },
                    {"Action", "DangNhap" }
                });
            }
        }
    }
}
