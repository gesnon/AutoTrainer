using AutoMapper;
using AutoTrainerDB;
using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.Characteristic;
using AutoTrainerServices.DTO.PersonCharacteristic;
using AutoTrainerServices.Services.Exeptions;
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
        private readonly IMapper mapper;
        public PersonCharacteristicService(ContextDB context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public GetPersonCharacteristicDTO GetPersonCharacteristicDTO(int ID)
        {
            PersonCharacteristic res = context.PersonCharacteristics.FirstOrDefault(_ => _.PersonCharacteristicID == ID);

            if (res == null)
            {
                throw new NotFoundExeption("{Характеристика не найдена");

            }
            return new GetPersonCharacteristicDTO { CharacteristicDTO=new GetCharacteristicDTO {Name=res.Characteristic.Name, CharacteristicID=res.Characteristic.ID }, PersonCharacteristicID=res.PersonCharacteristicID };
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
                throw new NotFoundExeption("{Характеристика не найдена");
            }            
            res.CharacteristicID = res.Characteristic.ID;           
            context.SaveChanges();
        }
        public PersonCharacteristic GetPersonCharacteristicByID(int ID)
        {
            PersonCharacteristic res = context.PersonCharacteristics.FirstOrDefault(_ => _.PersonCharacteristicID == ID);

            if (res == null)
            {
                throw new NotFoundExeption("{Характеристика не найдена");
            }
            return res;
        }
        public void DeletePersonCharacteristic(int ID)
        {
            PersonCharacteristic res = context.PersonCharacteristics.FirstOrDefault(_ => _.PersonCharacteristicID == ID);

            if (res == null)
            {
                throw new NotFoundExeption("{Характеристика не найдена");
            }
            context.PersonCharacteristics.Remove(res);
            context.SaveChanges();
        }

        public List<GetPersonCharacteristicDTO> GetPersonCharacteristicList(int ClientID)
        {
            Client client = context.Clients.FirstOrDefault(_ => _.ID == ClientID);
            if(client == null)
            {
                throw new NotFoundExeption("{Клиен не найден");
            }
            List<GetPersonCharacteristicDTO> res = client.PersonCharacteristics.Select(_ =>
            new GetPersonCharacteristicDTO
            {
                CharacteristicDTO = new GetCharacteristicDTO
                { Name = _.Characteristic.Name, CharacteristicID = _.Characteristic.ID },
                PersonCharacteristicID = _.PersonCharacteristicID
            }).ToList();

            return res;
        }
    }
}
