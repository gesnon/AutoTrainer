using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerDB.Models
{
    public class RoutineExercise
    {
        public Exercise Exercise { get; set; }
        public int ExerciseID { get; set; }
        public Muscle Muscle { get; set; }
        public int MuscleID { get; set; }
        public Level Level { get; set; }
        public int LevelID { get; set; }
        public Sex Sex { get; set; }
        public List<ExerciseCharacteristic> ExerciseCharacteristics { get; set; }
        public Purpose Purpose { get; set; }
        public int PurposeID { get; set; }
        public int ID { get; set; }
    }
}
