﻿namespace shopdecor_api.Models.DTO.OrderDTO
{
    public class CreateOrderDTO
    {
        public string? HoTen { get; set; }
        public string? DiaChi { get; set; }
        public string? SDT { get; set; }
        public string? Email { get; set; }
        public List<OrderDetailsDTO>? OrderDetails { get; set; }
    }
}