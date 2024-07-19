using AutoMapper;
using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO.DiscountDTO;

namespace shopdecor_api.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<KhuyenMai, IndexDiscountDTO>().ReverseMap();
            CreateMap<KhuyenMai, UpdateDiscountDTO>().ReverseMap();
        }
    }
}
