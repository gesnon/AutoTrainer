using AutoTrainerServices.DTO.Characteristic;
using AutoTrainerServices.DTO.RoutineExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.DTO.ExerciseCharacteristic
{
    public class GetExerciseCharacteristicDTO
    {
        public GetCharacteristicDTO CharacteristicDTO { get; set; }        
        public string RoutineExerciseName { get; set; }
        public int ExerciseCharacteristicID { get; set; }
    }
}
