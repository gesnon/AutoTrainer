using AutoTrainerDB;
using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.Exercise;
using AutoTrainerServices.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Servises
{
    public class ExerciseService : IExerciseService
    {
        private readonly ContextDB context;
        public ExerciseService(ContextDB context)
        {
            this.context = context;
        }
        public void CreateExercise(CreateExerciseDTO newExerciseCreateDTO)
        {
            context.Exercises.Add(new Exercise
            {
                Name = newExerciseCreateDTO.Name,
                Description = newExerciseCreateDTO.Description,
                Muscle = context.Muscles.FirstOrDefault(_ => _.ID == newExerciseCreateDTO.MuscleID)
            });
            context.SaveChanges();
        }

        public void UpdateExercise(UpdateExerciseDTO newExerciseUpdateDTO)
        {
            Exercise OldExercise = context.Exercises.FirstOrDefault(_ => _.ID == newExerciseUpdateDTO.ID);

            if (OldExercise == null)
            {
                throw new Exception("Упражнение не найдёно");
            }

            OldExercise.Name = newExerciseUpdateDTO.Name;
            OldExercise.Description = newExerciseUpdateDTO.Description;
            OldExercise.Muscle = context.Muscles.FirstOrDefault(_ => _.ID == newExerciseUpdateDTO.MuscleID);

            context.SaveChanges();
        }

        public void DeleteExercise(int ExerciseID)
        {
            if (context.Exercises.FirstOrDefault(_ => _.ID == ExerciseID) == null)
            {
                throw new Exception("Упражнение не найдёно");
            }

            context.Exercises.Remove(context.Exercises.FirstOrDefault(_ => _.ID == ExerciseID));

            context.SaveChanges();
        }

        public List<GetExerciseDTO> GetExercisesByName(string name)
        {
            var query = context.Exercises.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(_ => _.Name.Contains(name));
            }

            List<GetExerciseDTO> list = query.Select(_ => new GetExerciseDTO
            {
                Name = _.Name,
                Description = _.Description,
                Muscle = _.Muscle.Name,
                ID = _.ID
            }).ToList();

            return list;
        }

        public GetExerciseDTO GetExercise(int ExerciseID)
        {
            Exercise exercise = context.Exercises.FirstOrDefault(_ => _.ID == ExerciseID);
            if (exercise == null)
            {
                throw new Exception("Упражнение не найдено");
            }

            return new GetExerciseDTO
            {
                Name = exercise.Name,
                Description = exercise.Description,
                Muscle = exercise.Muscle.Name,
                ID = exercise.ID
            };
        }

        public List<GetExerciseDTO> GetAllExercise()
        {
            var query = context.Exercises.AsQueryable();

            List<GetExerciseDTO> list = query.Select(_ => new GetExerciseDTO
            {
                Name = _.Name,
                Description = _.Description,
                Muscle = _.Muscle.Name,
                ID = _.ID
            }).ToList();

            return list;
        }
    }
}
