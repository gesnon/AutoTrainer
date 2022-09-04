using AutoTrainerDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.DTO.Client
{
    public class CreateClientDTO
    {

        public string Name { get; set; }
        public Sex Sex { get; set; }
        public string Role { get; set; }
        public List<int> PersonCharacteristics { get; set; }
        public int PurposeID { get; set; }
        public int LevelID { get; set; }

    }
}
