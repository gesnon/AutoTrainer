using AutoMapper;
using AutoTrainerDB;
using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.ClientExercise;
using AutoTrainerServices.DTO.Exercise;
using AutoTrainerServices.DTO.RoutineExercise;
using AutoTrainerServices.DTO.TrainingDay;
using AutoTrainerServices.Services.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public class TrainingDayService : ITrainingDayService
    {
        private readonly ContextDB context;
        private readonly IMapper mapper;

        public IRoutineExerciseService routineExerciseService;
        public TrainingDayService(ContextDB context, IRoutineExerciseService routineExerciseService, IMapper mapper)
        {
            this.context = context;
            this.routineExerciseService = routineExerciseService;
            this.mapper=mapper;
        }

        public GetTrainingDayDTO getTrainingDayDTO(int ID)
        {
            
            TrainingDay trainingDay= context.TrainingDays.FirstOrDefault(x => x.ID == ID);            
            
            if (trainingDay == null)
            {
                throw new NotFoundExeption("{Тренировочный день не найден");
                
            } 

            GetTrainingDayDTO DTO = mapper.Map<TrainingDay, GetTrainingDayDTO>(trainingDay);

            return DTO;
        }

       
    }
}
