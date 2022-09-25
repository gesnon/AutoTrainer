using AutoTrainerServices.DTO.RoutineExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.DTO.ExerciseCharacteristic
{
    public class CreateExerciseCharacteristicDTO
    {        
        public int CharacteristicID { get; set; }        
        public int RoutineExerciseID { get; set; }        
    }
}
