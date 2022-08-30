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
            List<PersonCharacteristic> personCharacteristic = personCharacteristicService
                .CreatePersonCharacteristics(newClientDTO.PersonCharacteristics).ToList();

            context.Clients.Add(new Client
            {
                Name = newClientDTO.Name,
                Sex = newClientDTO.Sex,
                Role = newClientDTO.Role,
                Purpose = context.Purposes.FirstOrDefault(_ => _.ID == newClientDTO.PurposeID),
                Level = context.Levels.FirstOrDefault(_ => _.ID == newClientDTO.LevelID),
                PersonCharacteristics = personCharacteristic

            }) ;

            context.SaveChanges();
        }
    }
}
