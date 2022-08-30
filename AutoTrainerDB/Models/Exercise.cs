using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerDB.Models
{
    public class Exercise
    {
        public string Name { get; set; }

        public int ID { get; set; }

        public string Description { get; set; }

        public Muscle Muscle { get; set; }
    }
}
