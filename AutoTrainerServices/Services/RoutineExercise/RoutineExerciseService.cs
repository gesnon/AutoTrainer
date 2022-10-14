using AutoTrainerDB;
using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.Characteristic;
using AutoTrainerServices.DTO.Exercise;
using AutoTrainerServices.DTO.ExerciseCharacteristic;
using AutoTrainerServices.DTO.Level;
using AutoTrainerServices.DTO.Muscle;
using AutoTrainerServices.DTO.Purpose;
using AutoTrainerServices.DTO.RoutineExercise;
using AutoTrainerServices.Services.Exeptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public class RoutineExerciseService : IRoutineExerciseService
    {
        private readonly ContextDB context;
        public RoutineExerciseService(ContextDB context)
        {
            this.context = context;
        }

        public void CreateRoutineExercise(CreateRoutineExerciseDTO newRoutineExercise)
        {
            context.RoutineExercises.Add(new RoutineExercise
            {
                ExerciseID = newRoutineExercise.ExerciseID,
                LevelID = newRoutineExercise.LevelID,
                MuscleID = newRoutineExercise.MuscleID,
                Sex = (Sex)newRoutineExercise.Sex,
                PurposeID = newRoutineExercise.PurposeID,
                ExerciseCharacteristics = newRoutineExercise.ExerciseCharacteristicID
                .Select(_ => context.ExerciseCharacteristics
                .FirstOrDefault(c => c.ExerciseCharacteristicID == _)).ToList(),

            });

            context.SaveChanges();

        }

        public void UpdateRoutineExercise(UpdateRoutineExerciseDTO newRoutineExercise)
        {
            RoutineExercise OldRoutineExercise = context.RoutineExercises.FirstOrDefault(_ => _.ID == newRoutineExercise.RoutineExerciseID);

            if (OldRoutineExercise == null)
            {
                throw new NotFoundExeption("{Упражнение не найдено");
            }
            OldRoutineExercise.ExerciseID = newRoutineExercise.ExerciseID;
            OldRoutineExercise.LevelID = newRoutineExercise.LevelID;
            OldRoutineExercise.MuscleID = newRoutineExercise.MuscleID;
            OldRoutineExercise.Sex = (Sex)newRoutineExercise.Sex;
            OldRoutineExercise.PurposeID = newRoutineExercise.PurposeID;

            OldRoutineExercise.ExerciseCharacteristics = newRoutineExercise.ExerciseCharacteristicID
                .Select(_ => context.ExerciseCharacteristics
                .FirstOrDefault(c => c.ExerciseCharacteristicID == _)).ToList();

            context.SaveChanges();
        }

        public void DeleteRoutineExercise(int RoutineExerciseID)
        {
            RoutineExercise routineExercise = context.RoutineExercises.FirstOrDefault(_ => _.ID == RoutineExerciseID);
            if (routineExercise == null)
            {
                throw new NotFoundExeption("{Упражнение не найдено");
            }

            context.RoutineExercises.Remove(routineExercise);

            context.SaveChanges();
        }

        public List<RoutineExercise> ConvertFromClientExercises(List<ClientExercise> clientExercises)
        {
            List<RoutineExercise> result = clientExercises.Select(_ => new RoutineExercise { }).ToList();
            return result;
        }
        public List<RoutineExercise> GetRoutineExercisesWithLimitation(Client Client)
        {    
            List<int> clientCharacteristics = Client.PersonCharacteristics.Select(_ => _.CharacteristicID).ToList();
            List<RoutineExercise> routineExercises = context.RoutineExercises.Include(_ => _.ExerciseCharacteristics)
                .Include(_ => _.Exercise).Where(_ => _.LevelID == Client.LevelID && _.PurposeID == Client.PurposeID
                && _.Sex == Client.Sex || _.Sex == Sex.Unisex).ToList();

            return routineExercises;
        }
    }
}
