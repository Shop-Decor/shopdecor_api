using AutoMapper;
using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO.DiscountDTO;
using shopdecor_api.Models.DTO.ProductDTO;

namespace shopdecor_api.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<KhuyenMai, IndexDiscountDTO>().ReverseMap();
            CreateMap<KhuyenMai, UpdateDiscountDTO>().ReverseMap();
            CreateMap<SanPham, AddProductRequest>().ReverseMap();
        }
    }
}
