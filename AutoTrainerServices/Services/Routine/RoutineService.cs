using AutoMapper;
using AutoTrainerDB;
using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.Routine;
using AutoTrainerServices.DTO.TrainingDay;
using AutoTrainerServices.Services.Exeptions;
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
        public IRoutineExerciseService routineExerciseService;
        private readonly IMapper mapper;
        public RoutineService(ContextDB context, IClientExerciseService clientExerciseService, IMapper mapper, IRoutineExerciseService routineExerciseService)
        {
            this.context = context;
            this.clientExerciseService = clientExerciseService;
            this.mapper = mapper;
            this.routineExerciseService = routineExerciseService;
        }
        public void CreateNewRoutine(int ClientID)
        {
            Client client = context.Clients.FirstOrDefault(_ => _.ID == ClientID);
            if (client == null)
            {
                throw new NotFoundExeption("{Клиент не найден");
            }

            client.Routine = new Routine();
            client.Routine.TrainingWeeks = new List<TrainingWeek>();
            for (int i = 0; i < 4; i++)
            {
                TrainingWeek trainingWeek = new TrainingWeek { Name = "Название" };
                trainingWeek.TrainingDays = new List<TrainingDay>();
                for (int o = 0; o < 7; o++)
                {
                    trainingWeek.TrainingDays.Add(new TrainingDay { ClientExercises = new List<ClientExercise>() });
                }
                client.Routine.TrainingWeeks.Add(trainingWeek);
            }
        }
        public void ClearRoutine(Client Client)
        {
            foreach (TrainingWeek week in Client.Routine.TrainingWeeks)
            {
                foreach (TrainingDay day in week.TrainingDays)
                {
                    day.ClientExercises.Clear();
                }
            }
            context.SaveChanges();
        }
        public void DeleteRoutine(int RoutineID)
        {
            Routine routine = context.Routines.FirstOrDefault(_ => _.RoutineID == RoutineID);
            if (routine == null)
            {
                throw new NotFoundExeption("{Программа не найдена");
            }
            context.Routines.Remove(routine);
            context.SaveChanges();
        }
        public void CreateTrainingProgram(int ClientID, int num)
        {

            Client client = context.Clients.Include(_ => _.PersonCharacteristics)
                .Include(_ => _.Routine).ThenInclude(_ => _.TrainingWeeks).ThenInclude(_ => _.TrainingDays).ThenInclude(_ => _.ClientExercises)
                .ThenInclude(_ => _.RoutineExercise).FirstOrDefault(_ => _.ID == ClientID);

            if (client == null)
            {
                throw new NotFoundExeption("{Клиент не найден");
            }
            if (client.Routine != null)
            {
                ClearRoutine(client);
            }
            if (client.Routine == null)
            {
                CreateNewRoutine(ClientID);
            }

            List<RoutineExercise> routineExercises = routineExerciseService.GetRoutineExercisesWithLimitation(client);

            List<ClientExercise> clientExercises1 = routineExercises.GetRange(0, 6).Select(_ => new ClientExercise { RoutineExerciseID = _.ID }).ToList();

            List<ClientExercise> clientExercises2 = routineExercises.GetRange(6, 6).Select(_ => new ClientExercise { RoutineExerciseID = _.ID }).ToList();

            List<ClientExercise> clientExercises3 = routineExercises.GetRange(12, 6).Select(_ => new ClientExercise { RoutineExerciseID = _.ID }).ToList();
            
            
                client.Routine.TrainingWeeks[0].TrainingDays[0].ClientExercises.AddRange(clientExercises1);
                client.Routine.TrainingWeeks[0].TrainingDays[1].ClientExercises.AddRange(clientExercises2);
                client.Routine.TrainingWeeks[0].TrainingDays[2].ClientExercises.AddRange(clientExercises3);

            context.SaveChanges();

        }
        public GetRoutineDTO GetClientRoutine(int ClientID)
        {
            Client client = context.Clients.Include(_ => _.Routine).ThenInclude(_ => _.TrainingWeeks)
            .ThenInclude(_ => _.TrainingDays).ThenInclude(_ => _.ClientExercises)
            .ThenInclude(_ => _.RoutineExercise).FirstOrDefault(_ => _.ID == ClientID);
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
            if (client == null)
            {
                throw new NotFoundExeption("{Клиент не найден");
            }
            GetRoutineDTO DTO = mapper.Map<GetRoutineDTO>(client.Routine);

            return DTO;
        }
    }
}
