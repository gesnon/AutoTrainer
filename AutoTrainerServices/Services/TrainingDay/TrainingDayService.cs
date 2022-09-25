using AutoTrainerDB;
using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.ClientExercise;
using AutoTrainerServices.DTO.Exercise;
using AutoTrainerServices.DTO.RoutineExercise;
using AutoTrainerServices.DTO.TrainingDay;
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
        public TrainingDayService(ContextDB context)
        {
            this.context = context;
        }

        public GetTrainingDayDTO getTrainingDayDTO(int ID)
        {
            TrainingDay trainingDay= context.TrainingDays.FirstOrDefault(x => x.ID == ID);
            if (trainingDay == null)
            {
                return new GetTrainingDayDTO { Day=trainingDay.Day, ID = ID, TrainingWeekID=trainingDay.TrainingWeekID, 
                    ClientExercisesDTO=trainingDay.ClientExercises.Select(
                        _=> new GetClientExerciseDTO { ClientExerciseID=_.ClientExerciseID, TrainingDayID=_.TrainingDayID, 
                            RoutineExerciseDTO=new GetRoutineExerciseDTO{ExerciseDTO=new GetExerciseDTO{ }) };
            }
        }

        public void UpdateTrainingDayDTO();
    }
}
