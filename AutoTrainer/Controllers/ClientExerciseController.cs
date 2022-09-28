using AutoTrainerDB.Models;
using AutoTrainerServices.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoTrainer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientExerciseController
    {
        private readonly IClientExerciseService clientExerciseService;
        public ClientExerciseController(IClientExerciseService clientExerciseService)
        {
            this.clientExerciseService = clientExerciseService;
        }

        [HttpGet("{ClientID}/{MuscleID}")]
        public List<ClientExercise> GetTrainingProgram(int ClientID, int MuscleID)
        {
            return clientExerciseService.GetTrainingProgram(ClientID, MuscleID);
        }
    }
}
