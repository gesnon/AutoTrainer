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

        [HttpGet]
        public List<GetTrainingDayDTO> CreateTrainingProgram(int ClientID, int Num)
        {
            return routineService.CreateTrainingProgram(ClientID, Num);
        }
    }
}
