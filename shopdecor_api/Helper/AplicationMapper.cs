using AutoMapper;
using shopdecor_api.Data;
using shopdecor_api.Models.Domain;

namespace shopdecor_api.Helper
{
    public class AplicationMapper : Profile
    {
        public AplicationMapper()
        {
            CreateMap<SeabugDbContext,SanPham>().ReverseMap();
        }
    }
}
