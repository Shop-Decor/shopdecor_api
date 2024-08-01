namespace shopdecor_api.Models.DTO.OrderDTO
{
	public class OrderDTO
	{
		public int Id { get; set; }
		public DateTime NgayTao { get; set; }
		public DateTime NgayHuy { get; set; }

		public string? LyDoHuy { get; set; }
		public int ThanhTien { get; set; }
		// 0. Chờ xách nhận / 1. Đang giao / 2. Đã giao / 3.Đã Hủy
		public byte TTDonHang { get; set; }
		public bool TTThanhToan { get; set; }
	}
}
