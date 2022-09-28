using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.Level;
using AutoTrainerServices.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoTrainer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LevelController
    {
        private readonly ILevelService levelService;
        public LevelController(ILevelService levelService)
        {
            this.levelService = levelService;
        }

        [HttpPost]
        public void CreateLevel([FromBody] CreateLevelDTO DTO)
        {
            levelService.CreateLevel(DTO);
        }
        [HttpPut]
        public void UpdateLevel([FromBody] UpdateLevelDTO DTO)
        {
            levelService.UpdateLevel(DTO);
        }
        [HttpDelete("{ID}")]
        public void DeleteLevel(int ID)
        {
            levelService.DeleteLevel(ID);
        }

        [HttpGet]
        public List<GetLevelDTO> GetLevels()
        {
            return levelService.GetLevels();
        }
        [HttpGet("{ID}")]
        public Level GetLivelByID(int ID)
        {
            return levelService.GetLivelByID(ID);
        }
    }
}
