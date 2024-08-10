namespace shopdecor_api.Models.DTO.FilterDTO
{
    public class PagingResponseDTO<T> where T : class
    {
        public IEnumerable<T> list { get; set; }
        public PagingInfo paging { get; set; }
    }

    public class PagingInfo
    {
        public int index { get; set; }
        public int size { get; set; }
        public int totalPage { get; set; }
    }
}
