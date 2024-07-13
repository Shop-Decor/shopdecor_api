namespace shopdecor_api.Models.Domain
{
    public class HoaDon
    {
        public int Id { get; set; }
        public DateTime NgayXuatHD { get; set; }
        public virtual DonHang? DonHang { get; set; }
    }
}
