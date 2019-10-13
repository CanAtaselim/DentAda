
using AutoMapper;
using DentAda.Business.ViewModel.Administration;
using DentAda.Data.Model;

namespace DentAda.Business.BusinessLogic.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonVM>();
            CreateMap<Services, ServicesVM>();
            CreateMap<Banner, BannerVM>();
            CreateMap<Talent, TalentVM>();
        }

    }
}
