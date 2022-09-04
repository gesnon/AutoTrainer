using AutoTrainerServices.DTO.RoutineExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public interface IRoutineExerciseService
    {
        public void CreateRoutineExercise(CreateRoutineExerciseDTO newRoutineExercise);
    }
}
