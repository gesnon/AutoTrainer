using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.Characteristic;
using AutoTrainerServices.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoTrainer.Controllers
{
    [ApiController]
    [Route("API/Characteristic")]
    public class CharacteristicController
    {
        private readonly ICharacteristicService characteristicService;
        public CharacteristicController(ICharacteristicService characteristicService)
        {
            this.characteristicService = characteristicService;
        }


        [HttpPost]
        public void CreateCharacteristic([FromBody] CreateCharacteristicDTO newCreateCharacteristicDTO)
        {
            characteristicService.CreateCharacteristic(newCreateCharacteristicDTO);
        }
        [HttpPut]
        public void UpdateCharacteristic([FromBody]  UpdateCharacteristicDTO newUpdateCharacteristicDTO)
        {
            characteristicService.UpdateCharacteristic(newUpdateCharacteristicDTO);
        }
        [HttpGet("CharacteristicID")]
        public Characteristic GetCharacteristic(int CharacteristicID)
        {
            return characteristicService.GetCharacteristic(CharacteristicID);
        }
        [HttpGet("GetCharacteristicsByName/{Name?")]
        public List<GetCharacteristicDTO> GetCharacteristicsByName(string Name)
        {
            return GetCharacteristicsByName(Name);
        }
        [HttpDelete("CharacteristicID")]
        public void DeleteCharacteristic(int CharacteristicID)
        {
            characteristicService.DeleteCharacteristic(CharacteristicID);
        }
    }
}
