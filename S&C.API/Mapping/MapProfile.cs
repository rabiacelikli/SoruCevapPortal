using AutoMapper;
using S_C.API.Dtos;
using S_C.API.Models;


namespace uyg03.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Question, QuestionDto>().ReverseMap(); 
            CreateMap<Answer, AnswerDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}