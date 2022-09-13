using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerDB.Models
{
    public class PersonCharacteristic
    {
        public Characteristic Characteristic { get; set; }
        public int CharacteristicID { get; set; }
        public Client Client { get; set; }
        public int ClientID { get; set; }
        public int PersonCharacteristicID { get; set; }
    }
}
