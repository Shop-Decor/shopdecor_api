namespace shopdecor_api.Models.DTO.ProductDTO
{
    public class GetUserProductPaginationDTO
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<GetUserProduct> Items { get; set; }
    }
}
