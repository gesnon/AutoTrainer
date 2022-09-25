using AutoTrainerServices.DTO.TrainingWeek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.DTO.Routine
{
    public class UpdateRoutineDTO
    {
        public int ClientID { get; set; }
        public List<GetTrainingWeekDTO> TrainingWeeksDTO { get; set; }
        public int RoutineID { get; set; }
    }
}
