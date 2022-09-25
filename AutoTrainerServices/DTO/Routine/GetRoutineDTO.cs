using AutoTrainerServices.DTO.Client;
using AutoTrainerServices.DTO.TrainingWeek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.DTO.Routine
{
    public class GetRoutineDTO
    {
        public GetClientDTO ClientDTO { get; set; }
        public List<GetTrainingWeekDTO> TrainingWeeksDTO { get; set; }
        public int RoutineID { get; set; }
    }
}
