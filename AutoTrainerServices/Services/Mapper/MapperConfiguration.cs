using AutoMapper;
using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.ClientExercise;
using AutoTrainerServices.DTO.Exercise;
using AutoTrainerServices.DTO.Muscle;
using AutoTrainerServices.DTO.Routine;
using AutoTrainerServices.DTO.RoutineExercise;
using AutoTrainerServices.DTO.TrainingDay;
using AutoTrainerServices.DTO.TrainingWeek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            this.CreateMap<Routine, GetRoutineDTO>()
            .ForMember(_ => _.ClientDTO, opt => opt.MapFrom(i => i.Client))
            .ForMember(_ => _.RoutineID, opt => opt.MapFrom(i => i.RoutineID))
            .ForMember(_ => _.TrainingWeeksDTO, opt => opt.MapFrom(i => i.TrainingWeeks));            

            this.CreateMap<TrainingWeek, GetTrainingWeekDTO>()
            .ForMember(_ => _.Name, opt => opt.MapFrom(i => i.Name))
            .ForMember(_ => _.ID, opt => opt.MapFrom(i => i.ID))
            .ForMember(_ => _.RoutineID, opt => opt.MapFrom(i => i.RoutineID))
            .ForMember(_ => _.TrainingDaysDTO, opt => opt.MapFrom(i => i.TrainingDays));

            this.CreateMap<TrainingDay, GetTrainingDayDTO>()
            .ForMember(_ => _.ID, opt => opt.MapFrom(i => i.ID))
            .ForMember(_ => _.TrainingWeekID, opt => opt.MapFrom(i => i.TrainingWeekID))
            .ForMember(_ => _.Day, opt => opt.MapFrom(i => i.Day))
            .ForMember(_ => _.ClientExercisesDTO, opt => opt.MapFrom(i => i.ClientExercises));

            this.CreateMap<ClientExercise, GetClientExerciseDTO>()
            .ForMember(_ => _.ClientExerciseID, opt => opt.MapFrom(i => i.ClientExerciseID))
            .ForMember(_ => _.TrainingDayID, opt => opt.MapFrom(i => i.TrainingDayID))            
            .ForMember(_ => _.RoutineExerciseDTO, opt => opt.MapFrom(i => i.RoutineExercise));

            this.CreateMap<RoutineExercise, GetRoutineExerciseDTO>()
            .ForMember(_ => _.ID, opt => opt.MapFrom(i => i.ID))
            .ForMember(_ => _.ExerciseDTO, opt => opt.MapFrom(i => i.Exercise))
            .ForMember(_ => _.MuscleDTO, opt => opt.MapFrom(i => i.Muscle));

            this.CreateMap<Muscle, GetMuscleDTO>()
            .ForMember(_ => _.ID, opt => opt.MapFrom(i => i.ID))
            .ForMember(_ => _.Name, opt => opt.MapFrom(i => i.Name))
            .ForMember(_ => _.SubName, opt => opt.MapFrom(i => i.SubName));

            this.CreateMap<Exercise, GetExerciseDTO>()
            .ForMember(_ => _.ID, opt => opt.MapFrom(i => i.ID))
            .ForMember(_ => _.Name, opt => opt.MapFrom(i => i.Name))
            .ForMember(_ => _.Description, opt => opt.MapFrom(i => i.Description));
        }
    }
}
