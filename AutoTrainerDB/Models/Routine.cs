﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerDB.Models
{
    public class Routine
    {
        public Client Client { get; set; }
        public int ClientID { get; set; }
        public int ID { get; set; }
        public List<ClientExercise> ClientExercises { get; set; }

    }
}
