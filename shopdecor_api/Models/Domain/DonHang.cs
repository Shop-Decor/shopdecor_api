﻿using System.ComponentModel.DataAnnotations.Schema;

namespace shopdecor_api.Models.Domain
{
    public class DonHang
    {
        public int Id { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayHuy { get; set; }
        [Column(TypeName = "Nvarchar(max)")]
        public string? LyDoHuy { get; set; }
        // 0. Chờ xách nhận / 1. Đang giao / 2. Đã giao / 3.Đã Hủy
        public byte TTDonHang { get; set; }
        public bool TTThanhToan { get; set; }
        public virtual TaiKhoan? TaiKhoan { get; set; }
        public virtual KhuyenMai? KhuyenMai { get; set; }
        public virtual IEnumerable<HoaDon>? HoaDons { get; set; }
        public virtual IEnumerable<DonHang_ChiTiet>? DonHang_ChiTiets { get; set; }
    }
}
