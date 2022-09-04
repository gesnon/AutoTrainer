using AutoTrainerServices.DTO.Exercise;
using AutoTrainerServices.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoTrainer.Controllers
{
    [ApiController]
    [Route("API/Exercise")]
    public class ExerciseController
    {
        private readonly IExerciseService exerciseService;
        public ExerciseController(IExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }

        [HttpPost]
        public void CreateExercise([FromBody] CreateExerciseDTO newExerciseCreateDTO)
        {
            exerciseService.CreateExercise(newExerciseCreateDTO);
        }
        [HttpPut]
        public void UpdateExercise([FromBody] UpdateExerciseDTO newExerciseUpdateDTO)
        {
            exerciseService.UpdateExercise(newExerciseUpdateDTO);
        }
        [HttpDelete("{ExerciseID}")]
        public void DeleteExercise(int ExerciseID)
        {
            exerciseService.DeleteExercise(ExerciseID);
        }
        [HttpGet("GetExercisesByName/{Name?}")]
        public List<GetExerciseDTO> GetExercisesByName(string Name)
        {
            return exerciseService.GetExercisesByName(Name);
        }
        [HttpGet("{ExerciseID}")]
        public GetExerciseDTO GetExercise(int ExerciseID)
        {
           return exerciseService.GetExercise(ExerciseID);
        }
        [HttpGet]
        public List<GetExerciseDTO> GetAllExercise()
        {
            return exerciseService.GetAllExercise();
        }
    }
}
