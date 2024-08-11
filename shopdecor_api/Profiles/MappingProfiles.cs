using AutoMapper;
using shopdecor_api.Helper;
using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO;
using shopdecor_api.Models.DTO.Category_TypeDTO;
using shopdecor_api.Models.DTO.CategoryDTO;
using shopdecor_api.Models.DTO.ColorDTO;
using shopdecor_api.Models.DTO.DiscountDTO;
using shopdecor_api.Models.DTO.OrderDetailDTO;
using shopdecor_api.Models.DTO.OrderDTO;
using shopdecor_api.Models.DTO.ProductDTO;
using shopdecor_api.Models.DTO.SizeDTO;
using shopdecor_api.Models.DTO.StatisticalDTO;

namespace shopdecor_api.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<KhuyenMai, IndexDiscountDTO>().ReverseMap();

            CreateMap<KhuyenMai, UpdateDiscountDTO>().ReverseMap();

            CreateMap<KhuyenMai, AddDiscountDTO>().ReverseMap();

            CreateMap<SanPham, ProductWithDetailsDTO>().ReverseMap();

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

            CreateMap<SanPham_ChiTiet, IndexDTODetails>()
              .ForMember(dest => dest.MauSacId, opt => opt.MapFrom(src => src.MauSacId))
              .ForMember(dest => dest.KichThuocId, opt => opt.MapFrom(src => src.KichThuocId))
              .ReverseMap()
              .ForMember(dest => dest.MauSac, opt => opt.Ignore())
              .ForMember(dest => dest.KichThuoc, opt => opt.Ignore());

            CreateMap<SanPham_ChiTiet, DTODetails>()
                .ForMember(dest => dest.ColorId, opt => opt.MapFrom(src => src.MauSac.Id))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.MauSac.TenMauSac))
                .ForMember(dest => dest.SizeId, opt => opt.MapFrom(src => src.KichThuoc.Id))
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.KichThuoc.TenKichThuoc))
                .ReverseMap()
                .ForMember(dest => dest.MauSac, opt => opt.Ignore())
                .ForMember(dest => dest.KichThuoc, opt => opt.Ignore());

            CreateMap<SanPham_ChiTiet, DTOCreateProductDetails>().ReverseMap();
            CreateMap<SanPham_ChiTiet, DTOUpdateProductDetails>().ReverseMap();

            CreateMap<SanPham, UpdateProductRequest>().ReverseMap();

            CreateMap<IEnumerable<SanPham_Loai>, ProductCategory>()
                .ForMember(dest => dest.LoaiSPs, opt => opt.MapFrom(src => src.Select(sp => sp.LoaiSP.Id)));

            CreateMap<DonHang, OrderDTO>().ReverseMap();

            CreateMap<DonHang_ChiTiet, OrderDetailDTO>().ReverseMap();

            CreateMap<DonHang, OrderManagementDTO>()
                .ForMember(x => x.Detail, y => y.MapFrom(z => z.DonHang_ChiTiets))
                .ReverseMap();

            CreateMap<DonHang_ChiTiet, SubDetailedOrderManagementDTO>()
                .ForMember(x => x.Product, y => y.MapFrom(z => z.SanPham))
                .ReverseMap();

            CreateMap<SanPham, ProductSubForDetailedOrder>()
                .ForMember(x => x.hinh, y => y.MapFrom(z => z.Hinhs.FirstOrDefault().Link))
                .ReverseMap();

            CreateMap<DonHang, OrderDetailManagementDTO>()
                .ForMember(x => x.Detail, y => y.MapFrom(z => z.DonHang_ChiTiets))
                .ForMember(x => x.Discount, y => y.MapFrom(z => z.KhuyenMai))
                .ReverseMap();

            CreateMap<KhuyenMai, DiscountSubForDetailedOrder>()
                .ReverseMap();

            CreateMap<MauSac, ColorDTO>().ReverseMap();

            CreateMap<KichThuoc, SizeDTO>().ReverseMap();

            CreateMap<LoaiSP, GetCategoriesOnUser>().ReverseMap();

            CreateMap<PagedResult<SanPham>, GetUserProductPaginationDTO>().ReverseMap();

            CreateMap<StatisticalDTO, StatisticalDTO>().ReverseMap();
            CreateMap<IEnumerable<DonHang>, StatisticalDTO>()
               .ForMember(dest => dest.SoDonHang, opt => opt.MapFrom(src => src.Count()))
               .ForMember(dest => dest.TongDoanhThu, opt => opt.MapFrom(src => src.Sum(dh => dh.ThanhTien)));

        }
    }
}
