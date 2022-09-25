using AutoTrainerServices.DTO.TrainingDay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.DTO.TrainingWeek
{
    public class UpdateTrainingWeekDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<GetTrainingDayDTO> TrainingDaysDTO { get; set; }
        public int RoutineID { get; set; }
    }
}
