using BTL_Web_Nhom7.Models;
using Newtonsoft.Json;
using System.Globalization;

namespace BTL_Web_Nhom7.Service
{
	public class GioHangService
	{
		public const string GioHang = "GioHang";
		private readonly IHttpContextAccessor _context;
		private readonly HttpContext httpContext;
		
		public GioHangService(HttpContextAccessor context)
		{
			_context = context;
			httpContext = context.HttpContext;
		}

		public List<GioHang> GetCartItems()
		{

			var session = httpContext.Session;
			string jsoncart = session.GetString(GioHang);
			if (jsoncart != null)
			{
				return JsonConvert.DeserializeObject<List<GioHang>>(jsoncart);
			}
			return new List<GioHang>();
		}

		// Xóa cart khỏi session
		public void ClearCart()
		{
			var session = httpContext.Session;
			session.Remove(GioHang);
		}

		// Lưu Cart (Danh sách CartItem) vào session
		public void SaveCartSession(List<GioHang> ls)
		{
			var session = httpContext.Session;
			string jsoncart = JsonConvert.SerializeObject(ls);
			session.SetString(GioHang, jsoncart);
		}

	}
}
