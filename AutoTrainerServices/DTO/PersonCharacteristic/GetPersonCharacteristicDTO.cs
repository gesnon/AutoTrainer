using AutoTrainerServices.DTO.Characteristic;
using AutoTrainerServices.DTO.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.DTO.PersonCharacteristic
{
    public class GetPersonCharacteristicDTO
    {
        public GetCharacteristicDTO CharacteristicDTO { get; set; }        
        public int PersonCharacteristicID { get; set; }
    }
}
