using AutoTrainerDB;
using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.Purpose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public class PurposeService: IPurposeService
    {
        private readonly ContextDB context;
        public PurposeService(ContextDB context)
        {
            this.context = context;
        }
        public void CreatePurpose(CreatePurposeDTO DTO)
        {
            context.Purposes.Add(new Purpose { Name=DTO.Name });
            context.SaveChanges();
        }
        public void UpdatePurpose(UpdatePurposeDTO DTO)
        {
            Purpose OldPurpose = context.Purposes.FirstOrDefault(p => p.ID==DTO.ID);
            if (OldPurpose == null)
            {
                throw new Exception("Цель не найдена");
            }
            OldPurpose.Name = DTO.Name;
            context.SaveChanges();

        }
        public void DeletePurpose(int ID)
        {
            Purpose OldPurpose = context.Purposes.FirstOrDefault(p => p.ID == ID);
            if (OldPurpose == null)
            {
                throw new Exception("Цель не найдена");
            }
            context.Purposes.Remove(OldPurpose);
            context.SaveChanges();
        }
        public GetPurposeDTO GetPurposeByID(int ID)
        {
            Purpose OldPurpose = context.Purposes.FirstOrDefault(p => p.ID == ID);
            if (OldPurpose == null)
            {
                throw new Exception("Цель не найдена");
            }
            return new GetPurposeDTO { Name=OldPurpose.Name, ID= OldPurpose.ID };
        }
    }
}
