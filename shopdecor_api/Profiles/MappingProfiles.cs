using AutoMapper;
using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO;
using shopdecor_api.Models.DTO.Category_TypeDTO;
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
            CreateMap<SanPham, IndexProductRequest>()
                .ForMember(dest => dest.Hinhs, opt => opt.MapFrom(src => src.Hinhs.Select(h => h.Link)))
                .ReverseMap();
            CreateMap<SanPham, GetUserProduct>()
            .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.SanPham_ChiTiets.Select(ct => ct.MauSac.TenMauSac).Distinct().ToList()))
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.SanPham_ChiTiets.OrderBy(x => x.Gia).Select(x => x.MauSac.TenMauSac).FirstOrDefault()))
            .ForMember(dest => dest.Hinh, opt => opt.MapFrom(src => src.Hinhs.FirstOrDefault().Link))
            .ForMember(dest => dest.gia, opt => opt.MapFrom(src => src.SanPham_ChiTiets.Any() ? src.SanPham_ChiTiets.Min(s => s.Gia) : 0))
            .ForMember(dest => dest.LoaiGiam, opt => opt.MapFrom(x => x.KhuyenMai.LoaiGiam))
            .ForMember(dest => dest.MenhGia, opt => opt.MapFrom(x => x.KhuyenMai.MenhGia))
            .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.SanPham_ChiTiets.OrderBy(s => s.Gia).Select(s => s.KichThuoc.TenKichThuoc).FirstOrDefault()))
            .ForMember(dest => dest.SoLuong, opt => opt.MapFrom(src => src.SanPham_ChiTiets.OrderBy(s => s.Gia).Select(x => x.SoLuong).FirstOrDefault()))
            .ForMember(dest => dest.MaGiamGia, opt => opt.MapFrom(x => x.KhuyenMai.MaGiamGia))
            .ReverseMap();
            CreateMap<SanPham, UpdateProductRequest>().ReverseMap();

            CreateMap<SanPham_ChiTiet, DTODetails>().ReverseMap();
            CreateMap<IEnumerable<SanPham_Loai>, ProductCategory>()
            .ForMember(dest => dest.LoaiSPs, opt => opt.MapFrom(src => src.Select(sp => sp.LoaiSP.Id)));


        }
    }
}
