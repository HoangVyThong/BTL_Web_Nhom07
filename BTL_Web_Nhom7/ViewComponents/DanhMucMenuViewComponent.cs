using BTL_Web_Nhom7.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace BTL_Web_Nhom7.ViewComponents
{
    public class DanhMucMenuViewComponent : ViewComponent
    {
        private readonly IDanhMucRepository _danhMucRepository;
        public DanhMucMenuViewComponent(IDanhMucRepository danhMucRepository)
        {
            _danhMucRepository = danhMucRepository;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.DM1 = _danhMucRepository.DanhMuc1();
            ViewBag.DM2 = _danhMucRepository.DanhMuc2();
            ViewBag.DM3 = _danhMucRepository.DanhMuc3();
            ViewBag.DM4 = _danhMucRepository.DanhMuc4();
            ViewBag.DM5 = _danhMucRepository.DanhMuc5();
            ViewBag.DM6 = _danhMucRepository.DanhMuc6();
            ViewBag.DM7 = _danhMucRepository.DanhMuc7();
			return View(_danhMucRepository.GetAllDanhMuc());
        }
    }
}
