public class ProductDetail
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public bool Status { get; set; }
    public int DetailId { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }
    public string Size { get; set; }
    public string Color { get; set; }
    public bool DiscountType { get; set; } // Adjust the type according to LoaiGiam
    public int DiscountAmount { get; set; }
    public DateTime DiscountExpiryDate { get; set; }
}
