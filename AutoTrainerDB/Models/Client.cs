using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerDB.Models
{
    public class Client: Person
    {
        public Level Level { get; set; }       
        public List<PersonCharacteristic> PersonCharacteristics { get; set; }
        public Purpose Purpose { get; set; }
        public List<RoutineExercise> RoutineExercises { get; set; }
        public int ID { get; set; }
    }
}
