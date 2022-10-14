using AutoTrainerDB;
using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.Level;
using AutoTrainerServices.Services.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public class LevelService: ILevelService
    {
        private readonly ContextDB context;
        public LevelService(ContextDB context)
        {
            this.context = context;
        }
        public void CreateLevel(CreateLevelDTO DTO)
        {
            context.Levels.Add(new Level { Name=DTO.Name} );
            context.SaveChanges();
        }
        public void UpdateLevel(UpdateLevelDTO DTO)
        {
            Level level = context.Levels.FirstOrDefault(_ => _.ID == DTO.ID);
            if (level == null)
            {
                throw new NotFoundExeption("{Уровень подготовки не найден}");
            }
            level.Name = DTO.Name;
            context.SaveChanges();
        }
        public void DeleteLevel(int ID)
        {
            Level level = context.Levels.FirstOrDefault(_ => _.ID == ID);
            if (level == null)
            {
                throw new NotFoundExeption("{Уровень подготовки не найден}");
            }
            context.Levels.Remove(level);
            context.SaveChanges();

        }
        public List<GetLevelDTO> GetLevels()
        {
            List<GetLevelDTO> list = context.Levels.Select(_ => new GetLevelDTO { Name = _.Name, ID = _.ID }).ToList();
            return list;
        }
        public Level GetLivelByID(int ID)
        {
            Level level = context.Levels.FirstOrDefault(_ => _.ID == ID);
            if (level == null)
            {
                throw new NotFoundExeption("{Уровень подготовки не найден}");
            }
            return level;
        }
    }
}
