using AutoTrainerDB;
using AutoTrainerDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public class PersonCharacteristicService: IPersonCharacteristicService
    {
        private readonly ContextDB context;
        public PersonCharacteristicService(ContextDB context)
        {
            this.context = context;
        }
        public List<PersonCharacteristic> CreatePersonCharacteristics(List<int> characteristics)
        {
            List<PersonCharacteristic> personCharacteristics = new List<PersonCharacteristic>();
            foreach (int c in characteristics)
            {
                personCharacteristics.Add(new PersonCharacteristic { CharacteristicID = c });
            }
            return personCharacteristics;
        }
    }
}
