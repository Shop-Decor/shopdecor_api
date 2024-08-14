namespace shopdecor_api.Models.DTO.OrderDTO
{
    public class UpdateOrderUserDTO
    {
        public string? UserId { get; set; }
        public int OrderId { get; set; }
        public string? Reason { get; set; }
    }
}
