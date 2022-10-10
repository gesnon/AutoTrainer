using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.Routine;
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
        public void CreateTrainingProgram(int ClientID, int numberOfTrainingDays);

        public void CreateNewRoutine(int ClientID);

        public void DeleteRoutine(int RoutineID);

        public void ClearRoutine(Client Client);

        public GetRoutineDTO GetClientRoutine(int ClientID);
        
    }
}
