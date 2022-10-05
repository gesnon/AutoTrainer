using AutoTrainerServices.DTO.TrainingDay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public interface IRoutineService
    {
        public List<GetTrainingDayDTO> CreateTrainingProgram(int ClientID, int numberOfTrainingDays);

        
    }
}
