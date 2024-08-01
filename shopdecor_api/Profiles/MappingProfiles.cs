using AutoMapper;
using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO.DiscountDTO;
using shopdecor_api.Models.DTO.OrderDetailDTO;
using shopdecor_api.Models.DTO.OrderDTO;
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
            CreateMap<SanPham, IndexProductRequest>().ForMember(dest => dest.Hinhs, opt => opt.MapFrom(src => src.Hinhs.Select(h => h.Link))).ReverseMap();
            CreateMap<SanPham, UpdateProductRequest>().ReverseMap();
			CreateMap<DonHang, OrderDTO>().ReverseMap();
			CreateMap<DonHang_ChiTiet, OrderDetailDTO>().ReverseMap();
		}
    }
}
