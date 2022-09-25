using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.DTO.ClientExercise
{
    public class UpdateClientExerciseDTO
    {
        public int TrainingDayID { get; set; }
        public int RoutineExerciseID { get; set; }
        public int ClientExerciseID { get; set; }
    }
}
