using AutoTrainerServices.DTO.Exercise;
using AutoTrainerServices.DTO.RoutineExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.DTO.ClientExercise
{
    public class GetClientExerciseDTO
    {
        public int TrainingDayID { get; set; }
        public int RoutineExerciseID { get; set; }
        public GetRoutineExerciseDTO RoutineExerciseDTO { get; set; }
        public int ClientExerciseID { get; set; }
    }
}
