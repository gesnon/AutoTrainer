using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerDB.Models
{
    public class Client: Person
    {
        public Level Level { get; set; }
        public int LevelID { get; set; }
        public List<PersonCharacteristic> PersonCharacteristics { get; set; }
        public Purpose Purpose { get; set; }
        public int PurposeID { get; set; }

        [ForeignKey("RoutineID")]
        public Routine Routine { get; set; }
        public int RoutineID { get; set; }

    }
}
