using AutoMapper;
using AutoTrainerDB;
using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.ClientExercise;
using AutoTrainerServices.DTO.Exercise;
using AutoTrainerServices.DTO.RoutineExercise;
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
        private readonly IMapper mapper;
        public ClientExerciseService(ContextDB context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
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
                && _.Sex == client.Sex || _.Sex == Sex.Unisex).ToList();



            foreach (RoutineExercise r in routineExercises)
            {
                List<int> exerciseCharacteristics = r.ExerciseCharacteristics.Select(_ => _.CharacteristicID).ToList();

                List<int> check = clientCharacteristics.Intersect(exerciseCharacteristics).ToList();
                if (check.Count != 0)
                {
                    routineExercises.Remove(context.RoutineExercises.FirstOrDefault(_ => _.ExerciseID == r.ExerciseID));
                    continue;
                }

            }
            return trainingProgram;
        }

        public GetClientExerciseDTO GetClientExerciseDTO(int ID)
        {
            ClientExercise OldClientExercise = context.ClientExercises.FirstOrDefault(_ => _.ClientExerciseID == ID);

            if (OldClientExercise == null)
            {
                throw new Exception("Упражнение не найдено");
            }

            return mapper.Map<ClientExercise, GetClientExerciseDTO>(OldClientExercise);
        }
        public void CreateClientExercise(CreateClientExerciseDTO DTO)
        {
            context.ClientExercises.Add(new ClientExercise { RoutineExerciseID=DTO.RoutineExerciseID, TrainingDayID=DTO.TrainingDayID});
            context.SaveChanges();
        }
        public void UpdateClientExercise(UpdateClientExerciseDTO DTO)
        {
            ClientExercise OldClientExercise = context.ClientExercises.FirstOrDefault(_ => _.ClientExerciseID == DTO.ClientExerciseID);

            if (OldClientExercise == null)
            {
                throw new Exception("Упражнение не найдено");
            }
            OldClientExercise.RoutineExerciseID = DTO.RoutineExerciseID;
            OldClientExercise.TrainingDayID = DTO.TrainingDayID;
            context.SaveChanges();

        }
        public void DeleteClientExercise(int ClientExerciseID)
        {
            ClientExercise OldClientExercise = context.ClientExercises.FirstOrDefault(_ => _.ClientExerciseID == ClientExerciseID);

            if (OldClientExercise == null)
            {
                throw new Exception("Упражнение не найдено");
            }
            context.ClientExercises.Remove(OldClientExercise);

            context.SaveChanges();
        }
    }
}
