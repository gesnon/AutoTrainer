using AutoTrainerDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.DTO.RoutineExercise
{
    public class UpdateRoutineExerciseDTO
    {

        public int RoutineID { get; set; }
        public int ExerciseID { get; set; }
        public int Sex { get; set; }
        public int PurposeID { get; set; }
        public List<int> ExeptionsID { get; set; }
        public int MuscleID { get; set; }
        public int LevelID { get; set; }
        public int RoutineExerciseID { get; set; }
    }
}




