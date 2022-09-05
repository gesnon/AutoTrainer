using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerDB.Models
{
    public class ClientExercise
    {
        public int RoutineID { get; set; }
        public Routine Routine { get; set; }
        public int RoutineExerciseID { get; set; }
        public  RoutineExercise RoutineExercise { get; set; }
        public int ClientExerciseID { get; set; }
    }
}
