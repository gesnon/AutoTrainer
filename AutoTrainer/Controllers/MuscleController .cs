using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.Muscle;
using AutoTrainerServices.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoTrainer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MuscleController
    {
        private readonly IMuscleService muscleService;
        public MuscleController(IMuscleService muscleService)
        {
            this.muscleService = muscleService;
        }

        [HttpPost]
        public void CreateMuscle([FromBody] CreateMuscleDTO DTO)
        {
            muscleService.CreateMuscle(DTO);
        }
        [HttpPut]
        public void UpdateMuscle([FromBody] UpdateMuscleDTO DTO)
        {
            muscleService.UpdateMuscle(DTO);
        }
        [HttpDelete("{ID}")]
        public void DeleteMuscle(int ID)
        {
            muscleService.DeleteMuscle(ID);
        }

        [HttpGet("{Name}")]
        public List<GetMuscleDTO> GetMuscleByName(string Name)
        {
            return muscleService.GetMuscleByName(Name);
        }
        [HttpGet("{ID}")]
        public Muscle GetMuscle(int ID)
        {
            return muscleService.GetMuscle(ID);
        }

    }
}
