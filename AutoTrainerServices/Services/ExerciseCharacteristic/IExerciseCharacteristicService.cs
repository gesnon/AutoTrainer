using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.ExerciseCharacteristic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public interface IExerciseCharacteristicService
    {

        public void CreateExerciseCharacteristic(CreateExerciseCharacteristicDTO DTO);
        public void UpdateExerciseCharacteristic(UpdateExerciseCharacteristicDTO DTO);
        public void DeleteExerciseCharacteristic(int ID);
        public ExerciseCharacteristic GetExerciseCharacteristicByID(int ID);          
        public List<GetExerciseCharacteristicDTO>  GetExerciseCharacteristicByName(string Name);

    }
}
