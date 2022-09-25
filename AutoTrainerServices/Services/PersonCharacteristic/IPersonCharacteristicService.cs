using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.PersonCharacteristic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public interface IPersonCharacteristicService
    {
        public GetPersonCharacteristicDTO GetPersonCharacteristicDTO(int ID);
        public void CreatePersonCharacteristic(CreatePersonCharacteristicDTO createPersonCharacteristicDTO);
        public void UpdatePersonCharacteristic(UpdatePersonCharacteristicDTO updatePersonCharacteristicDTO);
        public List<GetPersonCharacteristicDTO> GetPersonCharacteristicByName(string Name);
        public PersonCharacteristic GetPersonCharacteristicByID(int ID);
        public void DeletePersonCharacteristic(int ID);
    }
}
