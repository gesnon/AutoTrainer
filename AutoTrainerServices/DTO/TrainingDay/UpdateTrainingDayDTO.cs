using AutoTrainerServices.DTO.ClientExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.DTO.TrainingDay
{
    public class UpdateTrainingDayDTO
    {
        public int ID { get; set; }
        public DayOfWeek Day { get; set; }
        public List<GetClientExerciseDTO> ClientExercisesDTO { get; set; }
        public int TrainingWeekID { get; set; }
    }
}
