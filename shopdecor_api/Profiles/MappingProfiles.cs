using AutoMapper;
using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO;
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
            CreateMap<KhuyenMai, AddDiscountDTO>().ReverseMap();
            CreateMap<SanPham, AddProductRequest>().ReverseMap();
            CreateMap<SanPham, IndexProductRequest>().ForMember(dest => dest.Hinhs, opt => opt.MapFrom(src => src.Hinhs.Select(h => h.Link))).ReverseMap();
            CreateMap<SanPham, UpdateProductRequest>().ReverseMap();
            CreateMap<SanPham_ChiTiet, DTODetails>().ReverseMap();
        }
    }
}
