using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.Characteristic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public interface ICharacteristicService
    {
        public void CreateCharacteristic(CreateCharacteristicDTO newCreateCharacteristicDTO);
        public void UpdateCharacteristic(UpdateCharacteristicDTO newUpdateCharacteristicDTO);
        public Characteristic GetCharacteristic(int CharacteristicID);
        public List<GetCharacteristicDTO> GetCharacteristicsByName(string Name);
        public void DeleteCharacteristic(int CharacteristicID);
    }
}
