using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerDB.Models
{
    public class TrainingWeek
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<TrainingDay> TrainingDays { get; set; }
        public int RoutineID { get; set; }
    }
}
