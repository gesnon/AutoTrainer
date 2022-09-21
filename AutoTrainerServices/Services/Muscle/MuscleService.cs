﻿using AutoTrainerDB;
using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.Muscle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public class MuscleService : IMuscleService
    {
        private readonly ContextDB context;
        public MuscleService(ContextDB context)
        {
            this.context = context;
        }

        public void CreateMuscle(CreateMuscleDTO newCreateMuscleDTO)
        {
            context.Muscles.Add(new Muscle
            {
                Name = newCreateMuscleDTO.Name,
                SubName = newCreateMuscleDTO.SubName
            });
            context.SaveChanges();
        }
        public void UpdateMuscle(UpdateMuscleDTO newUpdateMuscleDTO)
        {
            Muscle OldMuscle = context.Muscles.FirstOrDefault(_ => _.ID == newUpdateMuscleDTO.ID);

            if (OldMuscle == null)
            {
                throw new Exception("Мышца не найдена");
            }
            OldMuscle.Name = newUpdateMuscleDTO.Name;
            OldMuscle.SubName = newUpdateMuscleDTO.SubName;
            context.SaveChanges();
        }
        public Muscle GetMuscle(int MuscleID)
        {
            Muscle result = context.Muscles.FirstOrDefault(_ => _.ID == MuscleID);

            if (result == null)
            {
                throw new Exception("Мышца не найдена");
            }
            return result;
        }
        public List<GetMuscleDTO> GetMuscleByName(string Name)
        {
            List<Muscle> muscles = context.Muscles.Where(_ => _.Name.Contains(Name) && _.SubName.Contains(Name)).ToList();

            List<GetMuscleDTO> result = muscles
                .Select(_ => new GetMuscleDTO { Name = _.Name, SubName=_.SubName, ID = _.ID }).ToList();

            return result;
        }
        public void DeleteMuscle(int MuscleID)
        {
            Muscle result = context.Muscles.FirstOrDefault(_ => _.ID == MuscleID);

            if (result == null)
            {
                throw new Exception("Мышца не найдена");
            }
            context.Muscles.Remove(result);
            context.SaveChanges();
        }
    }
}
