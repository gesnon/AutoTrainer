using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerDB.Models
{
    public class RoutineExercise
    {

        public Routine Routine { get; set; }
        public int RoutineID { get; set; }
        public Exercise Exercise { get; set; }
        public int ExerciseID { get; set; }
        public Muscle Muscle { get; set; }
        public Level Level { get; set; }
        public Sex Sex { get; set; }
        public List<Characteristic> Exeptions { get; set; }
        public Purpose Purpose { get; set; }
        public int ID { get; set; }
    }
}
