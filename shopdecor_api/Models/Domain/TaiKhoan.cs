namespace shopdecor_api.Models.Domain
{
    public class TaiKhoan
    {
        public int Id { get; set; }
        public string? HoTen { get; set; }
        public string? DiaChi { get; set; }
        public string? SDT { get; set; }
        public string? Email { get; set; }
        public bool LoaiTK { get; set; }
        public DateTime NgayTao { get; set; }
        public bool TrangThai { get; set; }
        public virtual IEnumerable<DonHang>? DonHangs { get; set; }
    }
}
