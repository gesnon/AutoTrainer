using AutoMapper;
using AutoTrainerDB;
using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.Client;
using AutoTrainerServices.Services.Exeptions;
using AutoTrainerServices.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public class ClientService : IClientService
    {
        private readonly ContextDB context;
        public IPersonCharacteristicService personCharacteristicService;
        private readonly IMapper mapper;
        public ClientService(ContextDB context, IPersonCharacteristicService personCharacteristicService, IMapper mapper)
        {
            this.context = context;
            this.personCharacteristicService = personCharacteristicService;
            this.mapper = mapper;
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
            });

            context.SaveChanges();
        }
        public GetClientDTO GetClientByID(int CLientID)
        {
            Client client = context.Clients.FirstOrDefault(_ => _.ID == CLientID);
            if (client == null)
            {
                throw new NotFoundExeption("Клиент не найден");
            }
            GetClientDTO DTO = mapper.Map<GetClientDTO>(client);
           
            return DTO;
        }
        
        public List<GetClientDTO> GetClientsByName(string Name)
        {
            var query = context.Clients.AsQueryable();

            if (!string.IsNullOrEmpty(Name))
            {
                query = query.Where(_ => _.Name.Contains(Name));
            }

            List<GetClientDTO> list = query.Select(_ => mapper.Map<GetClientDTO>(_)).ToList();

            return list;
        }
        
        public void DeleteClient(int CLientID)
        {
            Client client = context.Clients.FirstOrDefault(_ => _.ID == CLientID);
            if (client == null)
            {
                throw new NotFoundExeption("Клиент не найден");
            }
            context.Clients.Remove(client);
            context.SaveChanges();
        }
    }
}
