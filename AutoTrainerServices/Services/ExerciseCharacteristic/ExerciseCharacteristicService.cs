using AutoMapper;
using AutoTrainerDB;
using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.Characteristic;
using AutoTrainerServices.DTO.ExerciseCharacteristic;
using AutoTrainerServices.Services.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public class ExerciseCharacteristicService : IExerciseCharacteristicService
    {
        private readonly ContextDB context;
        private readonly IMapper mapper;
        public ExerciseCharacteristicService(ContextDB context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public void CreateExerciseCharacteristic(CreateExerciseCharacteristicDTO DTO)
        {
            context.ExerciseCharacteristics.Add(new ExerciseCharacteristic { CharacteristicID = DTO.CharacteristicID, RoutineExerciseID = DTO.RoutineExerciseID });
            context.SaveChanges();
        }
        public void UpdateExerciseCharacteristic(UpdateExerciseCharacteristicDTO DTO)
        {
            ExerciseCharacteristic exerciseCharacteristic = context.ExerciseCharacteristics.FirstOrDefault(_ => _.ExerciseCharacteristicID == DTO.ExerciseCharacteristicID);
            if (exerciseCharacteristic == null)
            {
                throw new NotFoundExeption("{Упражнение не найдено");
            }
            exerciseCharacteristic.CharacteristicID = DTO.CharacteristicDTO.CharacteristicID;
            exerciseCharacteristic.RoutineExerciseID = DTO.RoutineExerciseDTO.ID;
            context.SaveChanges();
        }
        public void DeleteExerciseCharacteristic(int ID)
        {
            ExerciseCharacteristic exerciseCharacteristic = context.ExerciseCharacteristics.FirstOrDefault(_ => _.ExerciseCharacteristicID == ID);
            if (exerciseCharacteristic == null)
            {
                throw new NotFoundExeption("{Упражнение не найдено");
            }
            context.ExerciseCharacteristics.Remove(exerciseCharacteristic);
            context.SaveChanges();
        }
        public ExerciseCharacteristic GetExerciseCharacteristicByID(int ID)
        {
            ExerciseCharacteristic exerciseCharacteristic = context.ExerciseCharacteristics.FirstOrDefault(_ => _.ExerciseCharacteristicID == ID);
            if (exerciseCharacteristic == null)
            {
                throw new NotFoundExeption("{Упражнение не найдено");
            }
            return exerciseCharacteristic;
        }
        public List<GetExerciseCharacteristicDTO> GetExerciseCharacteristicByName(string name)
        {
            var query = context.ExerciseCharacteristics.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(_ => _.Characteristic.Name.Contains(name));
            }

            List<GetExerciseCharacteristicDTO> list = query.Select(_ => mapper.Map<GetExerciseCharacteristicDTO>(_)).ToList();

            return list;
        }
    }
}
