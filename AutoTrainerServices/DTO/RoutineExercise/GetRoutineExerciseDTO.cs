using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.Exercise;
using AutoTrainerServices.DTO.ExerciseCharacteristic;
using AutoTrainerServices.DTO.Level;
using AutoTrainerServices.DTO.Muscle;
using AutoTrainerServices.DTO.Purpose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.DTO.RoutineExercise
{
    public class GetRoutineExerciseDTO
    {   
        public GetExerciseDTO ExerciseDTO { get; set; }
        public GetMuscleDTO MuscleDTO { get; set; }
        public int ID { get; set; }
    }
}
