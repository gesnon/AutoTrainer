using AutoTrainerDB;
using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.Client;
using AutoTrainerServices.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public class ClientService: IClientService
    {
        private readonly ContextDB context;
        public IPersonCharacteristicService personCharacteristicService;
        public ClientService(ContextDB context, IPersonCharacteristicService personCharacteristicService)
        {
            this.context = context;
            this.personCharacteristicService = personCharacteristicService;
        }


        public void CreateClient(CreateClientDTO newClientDTO)    
        {
            context.Clients.Add(new Client
            {
                Name = newClientDTO.Name,
                Sex = newClientDTO.Sex,
                Role = newClientDTO.Role,
                PurposeID = newClientDTO.PurposeID,
                LevelID = newClientDTO.LevelID,
                PersonCharacteristics = newClientDTO.PersonCharacteristics
                .Select(_ => new PersonCharacteristic { CharacteristicID = _ }).ToList()
            }) ;

            context.SaveChanges();
        }

        public void DeleteClient(int ID)
        {
            Client client = context.Clients.FirstOrDefault(_ => _.ID == ID);
            if (client == null)
            {
                throw new Exception("Клиент не найден");
            }
            context.Clients.Remove(client);
            context.SaveChanges();
        }
    }
}
