using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerDB.Models
{
    public class ExerciseCharacteristic
    {
        public Characteristic Characteristic { get; set; }
        public int ExerciseCharacteristicID { get; set; }
        public RoutineExercise RoutineExercise { get; set; }
    }
}
