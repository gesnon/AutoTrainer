using AutoTrainerServices.DTO.Purpose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public interface IPurposeService
    {
        public void CreatePurpose(CreatePurposeDTO DTO);
        public void UpdatePurpose(UpdatePurposeDTO DTO);
        public void DeletePurpose(int ID);
        public List<GetPurposeDTO> GelAllPurposes();
        public GetPurposeDTO GetPurposeByID(int ID);
    }
}
