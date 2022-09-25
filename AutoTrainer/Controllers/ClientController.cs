using AutoTrainerServices.DTO.Client;
using AutoTrainerServices.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoTrainer.Controllers
{

    [ApiController]
    [Route("API/Client")]
    public class ClientController
    {
        private readonly IClientService clientService;
        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpPost]
        public void CreateClient([FromBody] CreateClientDTO newClientDTO)
        {
            clientService.CreateClient(newClientDTO);
        }

    }

}
