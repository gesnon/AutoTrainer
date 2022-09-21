using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerDB.Models
{
    public class Routine
    {
        public Client Client { get; set; }
        public int ClientID { get; set; }        
        public int TrainingWeekID { get; set; }        
        public List<TrainingWeek> TrainingWeeks { get; set; }

    }
}
