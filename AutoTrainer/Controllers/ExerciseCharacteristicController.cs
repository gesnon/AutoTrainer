using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.Characteristic;
using AutoTrainerServices.DTO.ExerciseCharacteristic;
using AutoTrainerServices.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoTrainer.Controllers
{
    [ApiController]
    [Route("API/Characteristic")]
    public class ExerciseCharacteristicController
    {
        private readonly IExerciseCharacteristicService exerciseCharacteristicService;
        public ExerciseCharacteristicController(IExerciseCharacteristicService exerciseCharacteristicService)
        {
            this.exerciseCharacteristicService = exerciseCharacteristicService;
        }

        [HttpPost]
        public void CreateExerciseCharacteristic([FromBody] CreateExerciseCharacteristicDTO DTO)
        {
            exerciseCharacteristicService.CreateExerciseCharacteristic(DTO);
        }
        [HttpPut]
        public void UpdateExerciseCharacteristic([FromBody] UpdateExerciseCharacteristicDTO DTO)
        {
            exerciseCharacteristicService.UpdateExerciseCharacteristic(DTO);
        }

        [HttpGet("ID")]
        public ExerciseCharacteristic GetExerciseCharacteristicByID(int ID)
        {
            return exerciseCharacteristicService.GetExerciseCharacteristicByID(ID);
        }
        [HttpGet("GetCharacteristicsByName/{Name?")]
        public List<GetCharacteristicDTO> GetCharacteristicsByName(string Name)
        {
            return GetCharacteristicsByName(Name);
        }
        [HttpDelete("ID")]
        public void DeleteExerciseCharacteristic(int ID)
        {
            exerciseCharacteristicService.DeleteExerciseCharacteristic(ID);
        }        

    }
}
