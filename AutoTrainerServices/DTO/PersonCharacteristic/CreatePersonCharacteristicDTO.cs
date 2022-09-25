﻿using AutoTrainerServices.DTO.Characteristic;
using AutoTrainerServices.DTO.Client;
using AutoTrainerServices.DTO.RoutineExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.DTO.PersonCharacteristic
{
    public class CreatePersonCharacteristicDTO
    {
        public GetCharacteristicDTO CharacteristicDTO { get; set; }
        public int CharacteristicID { get; set; }
        public GetClientDTO ClientDTO { get; set; }
        public int ClientID { get; set; }        
    }
}
