using AutoMapper;
using UserRegisterService.Application.Requests.User.DTOs;
using UserRegisterService.Domain.Entities;

namespace UserRegisterService.Application.Mapping;

public class ProfileMapper : Profile
{
   public ProfileMapper()
   {
      //**User**
      CreateMap<UserCreateDto, User>()
         .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
         .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
         .ForMember(dest =>dest.UserName, opt => opt.MapFrom(src => src.UserName))
         .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
         .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
         .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
     
      CreateMap<UserDeleteDto, User>()
         .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
         .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
         .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
         .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
         .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
         .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

      CreateMap<User, UserGetDto>()
         .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
         .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
         .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
         .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
         .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
         .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
         .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
         .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt));

      CreateMap<User, UserLoginDto>()
         .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserName))
         .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
   }
}