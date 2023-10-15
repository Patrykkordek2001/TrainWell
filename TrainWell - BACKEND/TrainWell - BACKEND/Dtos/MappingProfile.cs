using AutoMapper;
using TrainWell___BACKEND.Models;

namespace TrainWell___BACKEND.Dtos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WorkoutDto, Workout>();
            CreateMap<ExerciseDTO, Exercise>();
            CreateMap<ExerciseSetDTO, ExerciseSet>();
            CreateMap<UserDto, User>();
        }
    }
}
