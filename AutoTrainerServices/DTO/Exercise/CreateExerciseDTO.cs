﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.DTO.Exercise
{
    public class CreateExerciseDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int MuscleID { get; set; }
    }
}
