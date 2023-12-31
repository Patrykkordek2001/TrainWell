﻿using AutoMapper;
using TrainWell___BACKEND.Dtos.Diet;
using TrainWell___BACKEND.Dtos.Users;
using TrainWell___BACKEND.Dtos.Workouts;
using TrainWell___BACKEND.Models.Diet;
using TrainWell___BACKEND.Models.Training;
using TrainWell___BACKEND.Models.Users;
using TrainWell___BACKEND.Models.Workouts;

namespace TrainWell___BACKEND.Dtos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WorkoutDto, Workout>()
                .ForMember(dest => dest.ExercisesWorkout, opt => opt.MapFrom(src => src.ExercisesWorkout));
            CreateMap<ExerciseDto, Exercise>();
            CreateMap<ExerciseSetDto, ExerciseSet>();
            CreateMap<UserDto, User>();
            CreateMap<MealDto, Meal>();
            CreateMap<MeasurementsDto, Measurement>();
            CreateMap<ProductDto, Product>();
            CreateMap<MealProductDto, MealProduct>();
            CreateMap<UserInfoDto, UserInfo>();
            CreateMap<WorkoutUpdateDto, Workout>()
                .ForMember(dest => dest.ExercisesWorkout, opt => opt.MapFrom(src => src.ExercisesWorkout));
        }
    }
}