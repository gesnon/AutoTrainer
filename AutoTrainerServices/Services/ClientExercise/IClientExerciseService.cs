using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.ClientExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public interface IClientExerciseService
    {
        public List<ClientExercise> GetTrainingProgram(int ClientID, int MuscleID);

        public GetClientExerciseDTO GetClientExerciseDTO(int ID);
        public void CreateClientExercise(CreateClientExerciseDTO createClientExerciseDTO);        
        public void UpdateClientExercise(UpdateClientExerciseDTO updateClientExerciseDTO);
        public void DeleteClientExercise(int ClientExerciseID);
    }
}
