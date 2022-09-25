using AutoTrainerServices.DTO.Characteristic;
using AutoTrainerServices.DTO.ExerciseCharacteristic;
using AutoTrainerServices.DTO.RoutineExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.DTO.ExerciseCharacteristic
{
    public class UpdateExerciseCharacteristicDTO
    {
        public GetCharacteristicDTO CharacteristicDTO { get; set; }
        public GetRoutineExerciseDTO RoutineExerciseDTO { get; set; }
        public int ExerciseCharacteristicID { get; set; }
    }
}
