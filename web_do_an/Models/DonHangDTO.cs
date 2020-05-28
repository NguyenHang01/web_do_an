using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_do_an.Models
{
    public class DonHangDTO
    {
        public string MaDH { get; set; }
        public string MaKH { get; set; }
        public string Status { get; set; }
        public DateTime? NgayDat { get; set; }
        public double? SDT { get; set; }
        public string DiaChi { get; set; }
        public class Detail
        {
            public string MaDA { get; set; }

            public int? SoLuong { get; set; }

            public double? Gia { get; set; }

        }
        public IEnumerable<Detail> Details { get; set; }
    }
}