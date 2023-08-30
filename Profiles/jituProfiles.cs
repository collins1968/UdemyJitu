using UdemyJitu.Entities;
using UdemyJitu.Request;
using UdemyJitu.Responses;

namespace UdemyJitu.Profiles
{
    public class jituProfiles: AutoMapper.Profile
    {
       public jituProfiles()
        {
            CreateMap<AddUser, User>().ReverseMap();
            CreateMap<UserResponse, User>().ReverseMap();
            CreateMap<AddInstructor, Instructor>().ReverseMap();
            CreateMap<InstructorResponse, Instructor>().ReverseMap();
            CreateMap<AddCourse, Course>().ReverseMap();
            CreateMap<CourseResponse, Course>().ReverseMap();
        } 
        
    }
}
