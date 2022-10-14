using AutoTrainerServices.DTO.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public interface IClientService
    {
        public void CreateClient(CreateClientDTO newClientDTO);

        public GetClientDTO GetClientByID(int CLientID);

        public List<GetClientDTO> GetClientsByName(string Name);
        public void DeleteClient(int ID);
        
    }
}
