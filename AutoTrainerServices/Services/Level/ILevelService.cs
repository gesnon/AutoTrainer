using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public interface ILevelService
    {
        public void CreateLevel(CreateLevelDTO DTO);
        public void UpdateLevel(UpdateLevelDTO DTO);
        public void DeleteLevel(int ID);
        public List<GetLevelDTO> GetLevels();
        public Level GetLivelByID(int ID);
    }
}
