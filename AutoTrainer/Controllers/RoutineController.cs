using AutoTrainerServices.DTO.Routine;
using AutoTrainerServices.DTO.TrainingDay;
using AutoTrainerServices.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoTrainer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoutineController
    {
        private readonly IRoutineService routineService;
        public RoutineController(IRoutineService routineService)
        {
            this.routineService = routineService;
        }

        [HttpPost("CreateTrainingProgram")]
        public void CreateTrainingProgram(int ClientID, int Num)
        {
            routineService.CreateTrainingProgram(ClientID, Num);
        }

        [HttpPost]
        public void CreateNewRoutine(int ClientID)
        {
            routineService.CreateNewRoutine(ClientID);
        }

        [HttpDelete("{RoitineID}")]
        public void DeleteRoutine(int RoitineID)
        {
            routineService.DeleteRoutine(RoitineID);
        }

        [HttpGet("{ClientID}")]
        public GetRoutineDTO GetClientRoutine(int ClientID)
        {
            return routineService.GetClientRoutine(ClientID);
        }
    }
}
