using AutoTrainerDB;
using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.Exercise;
using AutoTrainerServices.Services.Exeptions;
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
                throw new NotFoundExeption("{Упражнение не найдено");
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
                throw new NotFoundExeption("{Упражнение не найдено");
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
                throw new NotFoundExeption("{Упражнение не найдено");
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
                // создание RoutineExercise для мужчины начального уровня подготовки с целью набрать массу
                new RoutineExercise {ExerciseID=1,MuscleID=1, LevelID=1, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=2,MuscleID=1, LevelID=1, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=3,MuscleID=1, LevelID=1, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=4,MuscleID=1, LevelID=1,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=1 }}},
                new RoutineExercise {ExerciseID=5,MuscleID=1, LevelID=1,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=2 }}},
                new RoutineExercise {ExerciseID=6,MuscleID=1, LevelID=1,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=3 }}},

                new RoutineExercise {ExerciseID=7,MuscleID=2, LevelID=1, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=8,MuscleID=2, LevelID=1, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=9,MuscleID=2, LevelID=1, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=10,MuscleID=2, LevelID=1,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=1 }}},
                new RoutineExercise {ExerciseID=11,MuscleID=2, LevelID=1,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=2 }}},
                new RoutineExercise {ExerciseID=12,MuscleID=2, LevelID=1,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=3 }}},

                new RoutineExercise {ExerciseID=13,MuscleID=3, LevelID=1, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=14,MuscleID=3, LevelID=1, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=15,MuscleID=3, LevelID=1, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=16,MuscleID=3, LevelID=1,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=1 }}},
                new RoutineExercise {ExerciseID=17,MuscleID=3, LevelID=1,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=2 }}},
                new RoutineExercise {ExerciseID=18,MuscleID=3, LevelID=1,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=3 }}},

                new RoutineExercise {ExerciseID=19,MuscleID=4, LevelID=1, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=20,MuscleID=4, LevelID=1, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=21,MuscleID=4, LevelID=1, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=22,MuscleID=4, LevelID=1,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=1 }}},
                new RoutineExercise {ExerciseID=23,MuscleID=4, LevelID=1,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=2 }}},
                new RoutineExercise {ExerciseID=24,MuscleID=4, LevelID=1,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=3 }}},

                new RoutineExercise {ExerciseID=25,MuscleID=5, LevelID=1, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=26,MuscleID=5, LevelID=1, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=27,MuscleID=5, LevelID=1, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=28,MuscleID=5, LevelID=1,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=1 }}},
                new RoutineExercise {ExerciseID=29,MuscleID=5, LevelID=1,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=2 }}},
                new RoutineExercise {ExerciseID=30,MuscleID=5, LevelID=1,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=3 }}},

                new RoutineExercise {ExerciseID=31,MuscleID=6, LevelID=1, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=32,MuscleID=6, LevelID=1, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=33,MuscleID=6, LevelID=1, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=34,MuscleID=6, LevelID=1,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=1 }}},
                new RoutineExercise {ExerciseID=35,MuscleID=6, LevelID=1,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=2 }}},
                new RoutineExercise {ExerciseID=36,MuscleID=6, LevelID=1,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=3 }}},

                new RoutineExercise {ExerciseID=37,MuscleID=7, LevelID=1, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=38,MuscleID=7, LevelID=1, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=39,MuscleID=7, LevelID=1, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=40,MuscleID=7, LevelID=1,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=1 }}},
                new RoutineExercise {ExerciseID=41,MuscleID=7, LevelID=1,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=2 }}},
                new RoutineExercise {ExerciseID=42,MuscleID=7, LevelID=1,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=3 }}},

                new RoutineExercise {ExerciseID=43,MuscleID=8, LevelID=1, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=44,MuscleID=8, LevelID=1, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=45,MuscleID=8, LevelID=1, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=46,MuscleID=8, LevelID=1,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=1 }}},
                new RoutineExercise {ExerciseID=47,MuscleID=8, LevelID=1,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=2 }}},
                new RoutineExercise {ExerciseID=48,MuscleID=8, LevelID=1,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=3 }}},                
               
                // создание RoutineExercise для мужчины среднего уровня подготовки с целью набрать массу
                new RoutineExercise {ExerciseID=1,MuscleID=1, LevelID=2, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=2,MuscleID=1, LevelID=2, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=3,MuscleID=1, LevelID=2, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=4,MuscleID=1, LevelID=2,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=1 }}},
                new RoutineExercise {ExerciseID=5,MuscleID=1, LevelID=2,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=2 }}},
                new RoutineExercise {ExerciseID=6,MuscleID=1, LevelID=2,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=3 }}},

                new RoutineExercise {ExerciseID=7,MuscleID=2, LevelID=2, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=8,MuscleID=2, LevelID=2, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=9,MuscleID=2, LevelID=2, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=10,MuscleID=2, LevelID=2,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=1 }}},
                new RoutineExercise {ExerciseID=11,MuscleID=2, LevelID=2,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=2 }}},
                new RoutineExercise {ExerciseID=12,MuscleID=2, LevelID=2,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=3 }}},

                new RoutineExercise {ExerciseID=13,MuscleID=3, LevelID=2, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=14,MuscleID=3, LevelID=2, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=15,MuscleID=3, LevelID=2, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=16,MuscleID=3, LevelID=2,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=1 }}},
                new RoutineExercise {ExerciseID=17,MuscleID=3, LevelID=2,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=2 }}},
                new RoutineExercise {ExerciseID=18,MuscleID=3, LevelID=2,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=3 }}},

                new RoutineExercise {ExerciseID=19,MuscleID=4, LevelID=2, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=20,MuscleID=4, LevelID=2, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=21,MuscleID=4, LevelID=2, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=22,MuscleID=4, LevelID=2,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=1 }}},
                new RoutineExercise {ExerciseID=23,MuscleID=4, LevelID=2,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=2 }}},
                new RoutineExercise {ExerciseID=24,MuscleID=4, LevelID=2,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=3 }}},

                new RoutineExercise {ExerciseID=25,MuscleID=5, LevelID=2, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=26,MuscleID=5, LevelID=2, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=27,MuscleID=5, LevelID=2, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=28,MuscleID=5, LevelID=2,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=1 }}},
                new RoutineExercise {ExerciseID=29,MuscleID=5, LevelID=2,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=2 }}},
                new RoutineExercise {ExerciseID=30,MuscleID=5, LevelID=2,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=3 }}},

                new RoutineExercise {ExerciseID=31,MuscleID=6, LevelID=2, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=32,MuscleID=6, LevelID=2, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=33,MuscleID=6, LevelID=2, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=34,MuscleID=6, LevelID=2,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=1 }}},
                new RoutineExercise {ExerciseID=35,MuscleID=6, LevelID=2,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=2 }}},
                new RoutineExercise {ExerciseID=36,MuscleID=6, LevelID=2,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=3 }}},

                new RoutineExercise {ExerciseID=37,MuscleID=7, LevelID=2, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=38,MuscleID=7, LevelID=2, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=39,MuscleID=7, LevelID=2, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=40,MuscleID=7, LevelID=2,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=1 }}},
                new RoutineExercise {ExerciseID=41,MuscleID=7, LevelID=2,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=2 }}},
                new RoutineExercise {ExerciseID=42,MuscleID=7, LevelID=2,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=3 }}},

                new RoutineExercise {ExerciseID=43,MuscleID=8, LevelID=2, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=44,MuscleID=8, LevelID=2, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=45,MuscleID=8, LevelID=2, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=46,MuscleID=8, LevelID=2,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=1 }}},
                new RoutineExercise {ExerciseID=47,MuscleID=8, LevelID=2,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=2 }}},
                new RoutineExercise {ExerciseID=48,MuscleID=8, LevelID=2,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=3 }}},
                
                // создание RoutineExercise для мужчины продвинутого уровня подготовки с целью набрать массу
                new RoutineExercise {ExerciseID=1,MuscleID=1, LevelID=3, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=2,MuscleID=1, LevelID=3, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=3,MuscleID=1, LevelID=3, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=4,MuscleID=1, LevelID=3,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=1 }}},
                new RoutineExercise {ExerciseID=5,MuscleID=1, LevelID=3,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=2 }}},
                new RoutineExercise {ExerciseID=6,MuscleID=1, LevelID=3,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=3 }}},

                new RoutineExercise {ExerciseID=7,MuscleID=2, LevelID=3, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=8,MuscleID=2, LevelID=3, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=9,MuscleID=2, LevelID=3, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=10,MuscleID=2, LevelID=3,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=1 }}},
                new RoutineExercise {ExerciseID=11,MuscleID=2, LevelID=3,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=2 }}},
                new RoutineExercise {ExerciseID=12,MuscleID=2, LevelID=3,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=3 }}},

                new RoutineExercise {ExerciseID=13,MuscleID=3, LevelID=3, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=14,MuscleID=3, LevelID=3, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=15,MuscleID=3, LevelID=3, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=16,MuscleID=3, LevelID=3,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=1 }}},
                new RoutineExercise {ExerciseID=17,MuscleID=3, LevelID=3,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=2 }}},
                new RoutineExercise {ExerciseID=18,MuscleID=3, LevelID=3,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=3 }}},

                new RoutineExercise {ExerciseID=19,MuscleID=4, LevelID=3, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=20,MuscleID=4, LevelID=3, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=21,MuscleID=4, LevelID=3, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=22,MuscleID=4, LevelID=3,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=1 }}},
                new RoutineExercise {ExerciseID=23,MuscleID=4, LevelID=3,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=2 }}},
                new RoutineExercise {ExerciseID=24,MuscleID=4, LevelID=3,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=3 }}},

                new RoutineExercise {ExerciseID=25,MuscleID=5, LevelID=3, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=26,MuscleID=5, LevelID=3, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=27,MuscleID=5, LevelID=3, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=28,MuscleID=5, LevelID=3,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=1 }}},
                new RoutineExercise {ExerciseID=29,MuscleID=5, LevelID=3,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=2 }}},
                new RoutineExercise {ExerciseID=30,MuscleID=5, LevelID=3,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=3 }}},

                new RoutineExercise {ExerciseID=31,MuscleID=6, LevelID=3, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=32,MuscleID=6, LevelID=3, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=33,MuscleID=6, LevelID=3, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=34,MuscleID=6, LevelID=3,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=1 }}},
                new RoutineExercise {ExerciseID=35,MuscleID=6, LevelID=3,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=2 }}},
                new RoutineExercise {ExerciseID=36,MuscleID=6, LevelID=3,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=3 }}},

                new RoutineExercise {ExerciseID=37,MuscleID=7, LevelID=3, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=38,MuscleID=7, LevelID=3, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=39,MuscleID=7, LevelID=3, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=40,MuscleID=7, LevelID=3,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=1 }}},
                new RoutineExercise {ExerciseID=41,MuscleID=7, LevelID=3,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=2 }}},
                new RoutineExercise {ExerciseID=42,MuscleID=7, LevelID=3,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=3 }}},

                new RoutineExercise {ExerciseID=43,MuscleID=8, LevelID=3, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=44,MuscleID=8, LevelID=3, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=45,MuscleID=8, LevelID=3, Sex=Sex.Male, PurposeID=2},
                new RoutineExercise {ExerciseID=46,MuscleID=8, LevelID=3,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=1 }}},
                new RoutineExercise {ExerciseID=47,MuscleID=8, LevelID=3,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=2 }}},
                new RoutineExercise {ExerciseID=48,MuscleID=8, LevelID=3,
                Sex=Sex.Male, PurposeID=2,ExerciseCharacteristics=new List<ExerciseCharacteristic>{new ExerciseCharacteristic{CharacteristicID=3 }}},
                };
                List<Client> clients = new List<Client>
                {
                    new Client{Name="Сергей",Role="Клиент", LevelID=1, PurposeID=2, Sex=Sex.Male },
                    new Client{Name="Иван",Role="Клиент", LevelID=2, PurposeID=2, Sex=Sex.Male },
                    new Client{Name="Михаил", Role="Клиент", LevelID=1, PurposeID=2, Sex=Sex.Male }
                };
                List<PersonCharacteristic> personCharacteristics = new List<PersonCharacteristic>
                {
                    new PersonCharacteristic{CharacteristicID=1, ClientID=2},
                    new PersonCharacteristic{CharacteristicID=1, ClientID=3},
                    new PersonCharacteristic{CharacteristicID=2, ClientID=3},
                    new PersonCharacteristic{CharacteristicID=3, ClientID=3},
                };
                List<Routine> routines = new List<Routine>
                {
                    new Routine{ClientID=1, TrainingWeeks=new List<TrainingWeek>() },
                    new Routine{ClientID=2, TrainingWeeks=new List<TrainingWeek>()},
                    new Routine{ClientID=3, TrainingWeeks=new List<TrainingWeek>()},

                };
                //context.Exercises.AddRange(exercises);
                //context.Muscles.AddRange(muscles);
                //context.Levels.AddRange(levels);
                //context.Purposes.AddRange(purposes);
                //context.Characteristics.AddRange(characteristics);
                //context.RoutineExercises.AddRange(routineExercises);
                //context.Clients.AddRange(clients);
                //context.PersonCharacteristics.AddRange(personCharacteristics);
                context.Routines.AddRange(routines);
                context.SaveChanges();
            }
        }
    }
}
