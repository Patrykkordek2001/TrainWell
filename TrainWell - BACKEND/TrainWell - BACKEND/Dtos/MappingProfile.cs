using AutoMapper;
using TrainWell___BACKEND.Models;
using TrainWell___BACKEND.Models.Diet;
using TrainWell___BACKEND.Models.Training;
using TrainWell___BACKEND.Models.User;

namespace TrainWell___BACKEND.Dtos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WorkoutDto, Workout>()
                .ForMember(dest => dest.ExerciseWorkouts, opt => opt.MapFrom(src => src.ExercisesWorkout));
            CreateMap<ExerciseDto, Exercise>();
            CreateMap<ExerciseSetDto, ExerciseSet>();
            CreateMap<UserDto, User>();
            CreateMap<MealDto, Meal>();
            CreateMap<MeasurementsDto, Measurement>();
            CreateMap<ProductDto, Product>();
            CreateMap<ProductInMealDto, ProductInMeal>();

        }
    }
}
