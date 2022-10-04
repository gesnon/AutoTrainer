using AutoMapper;
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
    public class RoutineService : IRoutineService
    {
        private readonly ContextDB context;
        public IClientExerciseService clientExerciseService;
        private readonly IMapper mapper;
        public RoutineService(ContextDB context, IClientExerciseService clientExerciseService, IMapper mapper)
        {
            this.context = context;
            this.clientExerciseService = clientExerciseService;
            this.mapper = mapper;
        }
        public void CreateTrainingProgram(int ClientID, int num)
        {
      
            Client client = context.Clients.FirstOrDefault(_ => _.ID == ClientID);
            if (client == null)
            {
                throw new Exception("Клиент не найден");
            }

            List<int> clientCharacteristics = client.PersonCharacteristics.Select(_ => _.CharacteristicID).ToList();
            List<RoutineExercise> routineExercises = context.RoutineExercises.Include(_ => _.ExerciseCharacteristics)
                .Where(_ => _.LevelID == client.LevelID && _.PurposeID == client.PurposeID
                && _.Sex == client.Sex || _.Sex == Sex.Unisex).ToList();

            int n = routineExercises.Count;
            Random rnd = new Random();
            while (n > 1)
            { 
                RoutineExercise a = routineExercises[n];
                RoutineExercise c = a;
                int rand = rnd.Next(0,routineExercises.Count);
                RoutineExercise b = routineExercises[rand];
                a = b;
                b = c;
                n--;
            }
            List<ClientExercise> exercises = routineExercises.GetRange(0, 6).Select(_ => new ClientExercise { RoutineExerciseID = _.ID }).ToList();
            foreach (TrainingWeek week in client.Routine.TrainingWeeks)
            {
                for (int i = 0; i < num; i++)
                {
                    week.TrainingDays[i].ClientExercises.AddRange(exercises);
                }
            }

        }
    }
}
