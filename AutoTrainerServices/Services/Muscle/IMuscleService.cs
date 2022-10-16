using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.Muscle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public interface IMuscleService
    {
        public int CreateMuscle(CreateMuscleDTO newCreateMuscleDTO);
        public void UpdateMuscle(UpdateMuscleDTO newUpdateMuscleDTO);
        public Muscle GetMuscle(int MuscleID);
        public List<GetMuscleDTO> GetMuscleByName(string Name);
        public void DeleteMuscle(int MuscleID);
    }
}
