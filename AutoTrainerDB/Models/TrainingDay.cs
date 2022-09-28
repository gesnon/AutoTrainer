using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerDB.Models
{
    public class TrainingDay
    {
        public int ID { get; set; }
        public DayOfWeek Day { get; set; }
        public List<ClientExercise> ClientExercises { get; set; }
        public int TrainingWeekID { get; set; }
        public TrainingWeek TrainingWeek { get; set; }
    }
}
