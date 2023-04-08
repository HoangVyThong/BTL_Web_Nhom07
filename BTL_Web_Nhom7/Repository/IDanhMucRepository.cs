using BTL_Web_Nhom7.Models;

namespace BTL_Web_Nhom7.Repository
{
    public interface IDanhMucRepository
    {
        public IEnumerable<DanhMuc> GetAllDanhMuc();

        public IEnumerable<LoaiThietBi> DanhMuc1();
        public IEnumerable<LoaiThietBi> DanhMuc2();
        public IEnumerable<LoaiThietBi> DanhMuc3();
        public IEnumerable<LoaiThietBi> DanhMuc4();
        public IEnumerable<LoaiThietBi> DanhMuc5();
        public IEnumerable<LoaiThietBi> DanhMuc6();
		public IEnumerable<LoaiThietBi> DanhMuc7();

	}
}
