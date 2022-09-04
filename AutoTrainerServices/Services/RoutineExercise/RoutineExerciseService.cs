﻿using AutoTrainerDB;
using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.RoutineExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public class RoutineExerciseService: IRoutineExerciseService
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
                Exercise = context.Exercises.FirstOrDefault(_ => _.ID == newRoutineExercise.ExerciseID),
                RoutineID = newRoutineExercise.RoutineID,
                Routine = context.Routines.FirstOrDefault(_ => _.ID == newRoutineExercise.RoutineID),
                Level = context.Levels.FirstOrDefault(_ => _.ID == newRoutineExercise.LevelID),
                Muscle = context.Muscles.FirstOrDefault(_ => _.ID == newRoutineExercise.MuscleID),
                Sex = (Sex)newRoutineExercise.Sex,
                Purpose = context.Purposes.FirstOrDefault(_ => _.ID == newRoutineExercise.PurposeID),
                
                Exeptions = newRoutineExercise.ExeptionsID
                .Select(_ => context.Characteristics
                .FirstOrDefault(c=>c.ID==_)).ToList(),                

            });

            context.SaveChanges();
            
        }


    }
}
