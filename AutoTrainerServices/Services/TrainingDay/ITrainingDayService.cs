using AutoTrainerServices.DTO.TrainingDay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public interface ITrainingDayService
    {
        public GetTrainingDayDTO getTrainingDayDTO(int TrainingDayID);
        
       


    }
}
