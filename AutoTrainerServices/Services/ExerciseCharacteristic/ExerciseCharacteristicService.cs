using AutoTrainerDB;
using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.Characteristic;
using AutoTrainerServices.DTO.ExerciseCharacteristic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public class ExerciseCharacteristicService: IExerciseCharacteristicService
    {
        private readonly ContextDB context;
        public ExerciseCharacteristicService(ContextDB context)
        {
            this.context = context;
        }
        public void CreateExerciseCharacteristic(CreateExerciseCharacteristicDTO DTO)
        {
            context.ExerciseCharacteristics.Add(new ExerciseCharacteristic { CharacteristicID = DTO.CharacteristicID, RoutineExerciseID = DTO.RoutineExerciseID });
            context.SaveChanges();
        }
        public void UpdateExerciseCharacteristic(UpdateExerciseCharacteristicDTO DTO)
        {
            ExerciseCharacteristic exerciseCharacteristic = context.ExerciseCharacteristics.FirstOrDefault(_=>_.ExerciseCharacteristicID==DTO.ExerciseCharacteristicID);
            if (exerciseCharacteristic == null)
            {
                throw new Exception("характеристика не найдена");
            }
            exerciseCharacteristic.CharacteristicID = DTO.CharacteristicID;
            exerciseCharacteristic.RoutineExerciseID= DTO.RoutineExerciseID;
            context.SaveChanges();
        }
        public void DeleteExerciseCharacteristic(int ID)
        {
            ExerciseCharacteristic exerciseCharacteristic = context.ExerciseCharacteristics.FirstOrDefault(_ => _.ExerciseCharacteristicID == ID);
            if (exerciseCharacteristic == null)
            {
                throw new Exception("характеристика не найдена");
            }
            context.ExerciseCharacteristics.Remove(exerciseCharacteristic);
            context.SaveChanges();
        }
        public ExerciseCharacteristic GetExerciseCharacteristicByID(int ID)
        {
            ExerciseCharacteristic exerciseCharacteristic = context.ExerciseCharacteristics.FirstOrDefault(_ => _.ExerciseCharacteristicID == ID);
            if (exerciseCharacteristic == null)
            {
                throw new Exception("характеристика не найдена");
            }
            return exerciseCharacteristic;
        }

    }
}
