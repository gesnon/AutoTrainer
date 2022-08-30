using AutoTrainerServices.DTO.Exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public interface IExerciseService
    {
        public void CreateExercise(CreateExerciseDTO newExerciseCreateDTO);
        public void UpdateExercise(UpdateExerciseDTO newExerciseUpdateDTO);
        public void DeleteExercise(int ExerciseID);
        public List<GetExerciseDTO> GetExercisesByName(string Name);
        public GetExerciseDTO GetExercise(int ExerciseID);
        public List<GetExerciseDTO> GetAllExercise();
    }
}
