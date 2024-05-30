using AutoMapper;
using LibrerySystem.DTOs;
using LibrerySystem.Models;

namespace LibrerySystem.Config
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Loan, CreateLoanDTO>()
                .ReverseMap()
                .ForMember(x => x.LoanId, opt => opt.Ignore());

            CreateMap<User, RegisterDTO>()
                .ForMember(x => x.Password, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<User, AuthenticatedUserDTO>()
               .ReverseMap()
               .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<AuthenticatedUserDTO, RegisterDTO>()
                .ReverseMap();
        }
    }
}
