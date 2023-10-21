using AutoMapper;
using TrainWell___BACKEND.Models;
using TrainWell___BACKEND.Models.Training;

namespace TrainWell___BACKEND.Dtos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WorkoutDto, Workout>();
            CreateMap<ExerciseDto, Exercise>();
            CreateMap<ExerciseSetDto, ExerciseSet>();
            CreateMap<UserDto, User>();
            CreateMap<MeasurementsDto, Measurement>();

        }
    }
}
