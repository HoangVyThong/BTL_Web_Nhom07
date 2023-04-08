using BTL_Web_Nhom7.Models;

namespace BTL_Web_Nhom7.Repository
{
    public class DanhMucRepository : IDanhMucRepository
    {
        private readonly BtlWebContext _context;

        public DanhMucRepository(BtlWebContext context)
        {
            _context = context;
        }

		public IEnumerable<LoaiThietBi> DanhMuc1()
		{
			return _context.LoaiThietBis.Where(x => x.MaDanhMuc == "DM1").ToList();
		}

		public IEnumerable<LoaiThietBi> DanhMuc2()
		{
			return _context.LoaiThietBis.Where(x => x.MaDanhMuc == "DM2").ToList();
		}

		public IEnumerable<LoaiThietBi> DanhMuc3()
		{
			return _context.LoaiThietBis.Where(x => x.MaDanhMuc == "DM3").ToList();
		}

		public IEnumerable<LoaiThietBi> DanhMuc4()
		{
			return _context.LoaiThietBis.Where(x => x.MaDanhMuc == "DM4").ToList();
		}

		public IEnumerable<LoaiThietBi> DanhMuc5()
		{
			return _context.LoaiThietBis.Where(x => x.MaDanhMuc == "DM5").ToList();
		}

		public IEnumerable<LoaiThietBi> DanhMuc6()
		{
			return _context.LoaiThietBis.Where(x => x.MaDanhMuc == "DM6").ToList();
		}

		public IEnumerable<LoaiThietBi> DanhMuc7()
		{
			return _context.LoaiThietBis.Where(x => x.MaDanhMuc == "DM7").ToList();
		}

		public IEnumerable<DanhMuc> GetAllDanhMuc()
        {
            return _context.DanhMucs.ToList();
        }
    }
}
