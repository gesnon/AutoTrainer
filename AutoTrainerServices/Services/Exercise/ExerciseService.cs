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
                Description = newExerciseCreateDTO.Description
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

            context.SaveChanges();
        }

        public void DeleteExercise(int ExerciseID)
        {
            Exercise exercise = context.Exercises.FirstOrDefault(_ => _.ID == ExerciseID);
            if (exercise == null)
            {
                throw new Exception("Упражнение не найдёно");
            }

            context.Exercises.Remove(exercise);

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
                ID = _.ID
            }).ToList();

            return list;
        }

        public void AddData()
        {
            {
                List<Exercise> exercises = new List<Exercise>
                {
                    new Exercise { Name = "Упражнение на Грудные мышцы 1", Description = "Описание" },
                    new Exercise { Name = "Упражнение на Грудные мышцы 2", Description = "Описание" },
                    new Exercise { Name = "Упражнение на Грудные мышцы 3", Description = "Описание" },
                    new Exercise { Name = "Упражнение на Грудные мышцы 4", Description = "Описание" },
                    new Exercise { Name = "Упражнение на Грудные мышцы 5", Description = "Описание" },
                    new Exercise { Name = "Упражнение на Грудные мышцы 6", Description = "Описание" },

                    new Exercise { Name = "Упражнение на бицепс 1", Description = "Описание" },
                    new Exercise { Name = "Упражнение на бицепс 2", Description = "Описание" },
                    new Exercise { Name = "Упражнение на бицепс 3", Description = "Описание" },
                    new Exercise { Name = "Упражнение на бицепс 4", Description = "Описание" },
                    new Exercise { Name = "Упражнение на бицепс 5", Description = "Описание" },
                    new Exercise { Name = "Упражнение на бицепс 6", Description = "Описание" },

                    new Exercise { Name = "Упражнение на трицепс 1", Description = "Описание" },
                    new Exercise { Name = "Упражнение на трицепс 2", Description = "Описание" },
                    new Exercise { Name = "Упражнение на трицепс 3", Description = "Описание" },
                    new Exercise { Name = "Упражнение на трицепс 4", Description = "Описание" },
                    new Exercise { Name = "Упражнение на трицепс 5", Description = "Описание" },
                    new Exercise { Name = "Упражнение на трицепс 6", Description = "Описание" },

                    new Exercise { Name = "Упражнение на квадрицепс 1", Description = "Описание" },
                    new Exercise { Name = "Упражнение на квадрицепс 2", Description = "Описание" },
                    new Exercise { Name = "Упражнение на квадрицепс 3", Description = "Описание" },
                    new Exercise { Name = "Упражнение на квадрицепс 4", Description = "Описание" },
                    new Exercise { Name = "Упражнение на квадрицепс 5", Description = "Описание" },
                    new Exercise { Name = "Упражнение на квадрицепс 6", Description = "Описание" },

                    new Exercise { Name = "Упражнение на ягодичную мышцу 1", Description = "Описание" },
                    new Exercise { Name = "Упражнение на ягодичную мышцу 2", Description = "Описание" },
                    new Exercise { Name = "Упражнение на ягодичную мышцу 3", Description = "Описание" },
                    new Exercise { Name = "Упражнение на ягодичную мышцу 4", Description = "Описание" },
                    new Exercise { Name = "Упражнение на ягодичную мышцу 5", Description = "Описание" },
                    new Exercise { Name = "Упражнение на ягодичную мышцу 6", Description = "Описание" },

                    new Exercise { Name = "Упражнение на дельтовидную мышцу 1", Description = "Описание" },
                    new Exercise { Name = "Упражнение на дельтовидную мышцу 2", Description = "Описание" },
                    new Exercise { Name = "Упражнение на дельтовидную мышцу 3", Description = "Описание" },
                    new Exercise { Name = "Упражнение на дельтовидную мышцу 4", Description = "Описание" },
                    new Exercise { Name = "Упражнение на дельтовидную мышцу 5", Description = "Описание" },
                    new Exercise { Name = "Упражнение на дельтовидную мышцу 6", Description = "Описание" },                 

                    new Exercise { Name = "Упражнение на спину 1", Description = "Описание" },
                    new Exercise { Name = "Упражнение на спину 2", Description = "Описание" },
                    new Exercise { Name = "Упражнение на спину 3", Description = "Описание" },
                    new Exercise { Name = "Упражнение на спину 4", Description = "Описание" },
                    new Exercise { Name = "Упражнение на спину 5", Description = "Описание" },
                    new Exercise { Name = "Упражнение на спину 6", Description = "Описание" },

                    new Exercise { Name = "Упражнение на мышцы пресса 1", Description = "Описание" },
                    new Exercise { Name = "Упражнение на мышцы пресса 2", Description = "Описание" },
                    new Exercise { Name = "Упражнение на мышцы пресса 3", Description = "Описание" },
                    new Exercise { Name = "Упражнение на мышцы пресса 4", Description = "Описание" },
                    new Exercise { Name = "Упражнение на мышцы пресса 5", Description = "Описание" },
                    new Exercise { Name = "Упражнение на мышцы пресса 6", Description = "Описание" },
                    };

                List<Muscle> muscles = new List<Muscle> {
                    new Muscle { Name = "Грудные" },
                    new Muscle { Name = "Бицепс" },
                    new Muscle { Name = "Трицепс" },
                    new Muscle { Name = "Квадрицепс" },
                    new Muscle { Name = "Ягодичная" },
                    new Muscle { Name = "Дельтовидная" },
                    new Muscle { Name = "Мышцы спины" },
                    new Muscle { Name = "Мышцы пресса" }
                };

                List<Level> levels = new List<Level>
                {
                new Level { Name ="Начинающий"},
                new Level { Name ="Средний"},
                new Level{Name="Продвинутый"}
                };
                List<Purpose> purposes = new List<Purpose>
                {
                    new Purpose { Name ="Похудение"},
                    new Purpose{ Name ="Набор массы"}
                };
                List<Characteristic> characteristics = new List<Characteristic>
                {
                new Characteristic{Name="Сколиоз"},
                new Characteristic{Name="Грыжа"},
                new Characteristic{Name="Артрит"}
                };

                List<RoutineExercise> routineExercises = new List<RoutineExercise>
                {
                new RoutineExercise {ExerciseID=1,MuscleID=1, LevelID=1, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=2,MuscleID=1, LevelID=1, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=3,MuscleID=1, LevelID=1, Sex=Sex.Male, PurposeID=2},                

                new RoutineExercise {ExerciseID=4,MuscleID=1, LevelID=1,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=1 }}},

                new RoutineExercise {ExerciseID=5,MuscleID=1, LevelID=1,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=2 }}},

                new RoutineExercise {ExerciseID=6,MuscleID=1, LevelID=1,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=3 }}},
                    
                };


                //context.Muscles.AddRange(muscles);
                //context.Exercises.AddRange(exercises);
                //context.Levels.AddRange(levels);
                //context.Purposes.AddRange(purposes);
                //context.Characteristics.AddRange(characteristics);
                //context.RoutineExercises.AddRange(routineExercises);
                 

                context.SaveChanges();
            }
        }
    }
}
