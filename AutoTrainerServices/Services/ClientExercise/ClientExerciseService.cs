using AutoTrainerDB;
using AutoTrainerDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public class ClientExerciseService : IClientExerciseService
    {
        private readonly ContextDB context;
        
        public ClientExerciseService(ContextDB context)
        {
            this.context = context;            
        }

        public List<ClientExercise> GetTrainingProgram(int ClientID, int MuscleID)
        {
            Client client = context.Clients.Include(_ => _.PersonCharacteristics).FirstOrDefault(_ => _.ID == ClientID);
            if (client == null)
            {
                throw new Exception("Клиент не найден");
            }

            List<ClientExercise> trainingProgram = new List<ClientExercise>();
            List<int> clientCharacteristics = client.PersonCharacteristics.Select(_ => _.CharacteristicID).ToList();
            List<RoutineExercise> routineExercises = context.RoutineExercises.Include(_ => _.ExerciseCharacteristics)
                .Where(_ => _.LevelID == client.LevelID && _.MuscleID == MuscleID && _.PurposeID == client.PurposeID 
                && _.Sex == client.Sex|| _.Sex == Sex.Unisex).ToList();
            
            

            foreach (RoutineExercise r in routineExercises)
            {
                List<int> exerciseCharacteristics = r.ExerciseCharacteristics.Select(_ => _.CharacteristicID).ToList();

                List<int> check = clientCharacteristics.Intersect(exerciseCharacteristics).ToList();
                if (check.Count != 0)
                {
                    routineExercises.Remove(context.RoutineExercises.FirstOrDefault(_=>_.ExerciseID==r.ExerciseID));
                    continue;
                }
                trainingProgram.Add(new ClientExercise { ClientExerciseID = client.ID, RoutineExerciseID = r.ID });
            }
            return trainingProgram;
        }
    }
}
