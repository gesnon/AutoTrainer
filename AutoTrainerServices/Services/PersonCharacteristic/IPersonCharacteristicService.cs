using AutoTrainerDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public interface IPersonCharacteristicService
    {
        public List<PersonCharacteristic> CreatePersonCharacteristics(List<int> characteristics);
    }
}
