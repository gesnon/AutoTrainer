using AutoTrainerDB;
using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.PersonCharacteristic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public class PersonCharacteristicService : IPersonCharacteristicService
    {
        private readonly ContextDB context;
        public PersonCharacteristicService(ContextDB context)
        {
            this.context = context;
        }

        public GetPersonCharacteristicDTO GetPersonCharacteristicDTO(int ID)
        {
            PersonCharacteristic res = context.PersonCharacteristics.FirstOrDefault(_ => _.PersonCharacteristicID == ID);

            if (res == null)
            {
                throw new Exception("Характеристика не найдена");

            }
            return new GetPersonCharacteristicDTO { CharacteristicID = res.CharacteristicID, ClientID = res.ClientID, PersonCharacteristicID = res.PersonCharacteristicID };
        }

        public List<GetPersonCharacteristicDTO> GetPersonCharacteristicByName(string name)
        {
            var query = context.PersonCharacteristics.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(_ => _.Characteristic.Name.Contains(name));
            }

            List<GetPersonCharacteristicDTO> list = query.Select(_ => new GetPersonCharacteristicDTO
            {
                CharacteristicID=_.CharacteristicID,
                ClientID=_.ClientID,
            }).ToList();

            return list;
        }
        public void CreatePersonCharacteristic(CreatePersonCharacteristicDTO DTO)
        {
            context.PersonCharacteristics.Add(new PersonCharacteristic { CharacteristicID = DTO.CharacteristicID, ClientID = DTO.ClientID });
            context.SaveChanges();
        }
        public void UpdatePersonCharacteristic(UpdatePersonCharacteristicDTO DTO)
        {
            PersonCharacteristic res = context.PersonCharacteristics.FirstOrDefault(_ => _.PersonCharacteristicID == DTO.PersonCharacteristicID);

            if (res == null)
            {
                throw new Exception("Характеристика не найдена");

            }
            res.CharacteristicID = DTO.CharacteristicID;
            res.ClientID = DTO.ClientID;
            context.SaveChanges();
        }
        public PersonCharacteristic GetPersonCharacteristicByID(int ID)
        {
            PersonCharacteristic res = context.PersonCharacteristics.FirstOrDefault(_ => _.PersonCharacteristicID == ID);

            if (res == null)
            {
                throw new Exception("Характеристика не найдена");

            }
            return res;
        }
        public void DeletePersonCharacteristic(int ID)
        {
            PersonCharacteristic res = context.PersonCharacteristics.FirstOrDefault(_ => _.PersonCharacteristicID == ID);

            if (res == null)
            {
                throw new Exception("Характеристика не найдена");

            }
            context.PersonCharacteristics.Remove(res);
            context.SaveChanges();
        }
    }
}
