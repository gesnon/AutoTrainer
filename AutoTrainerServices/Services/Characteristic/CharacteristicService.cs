using AutoTrainerDB;
using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.Characteristic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerServices.Services.Services
{
    public class CharacteristicService : ICharacteristicService
    {
        private readonly ContextDB context;
        public CharacteristicService(ContextDB context)
        {
            this.context = context;
        }

        public void CreateCharacteristic(CreateCharacteristicDTO newCreateCharacteristicDTO)
        {
            context.Characteristics.Add(new Characteristic { Name = newCreateCharacteristicDTO.Name });
            context.SaveChanges();
        }
        public void UpdateCharacteristic(UpdateCharacteristicDTO newUpdateCharacteristicDTO)
        {
            Characteristic OldCharacteristic = context.Characteristics.FirstOrDefault(c => c.ID == newUpdateCharacteristicDTO.CharacteristicID);

            if (OldCharacteristic != null)
            {
                throw new Exception("Характеристика не найдена");

            }
            OldCharacteristic.Name = newUpdateCharacteristicDTO.Name;
            context.SaveChanges();
        }
        public Characteristic GetCharacteristic(int CharacteristicID)
        {
            Characteristic OldCharacteristic = context.Characteristics.FirstOrDefault(c => c.ID == CharacteristicID);

            if (OldCharacteristic != null)
            {
                throw new Exception("Характеристика не найдена");

            }

            return OldCharacteristic;
        }

        public List<GetCharacteristicDTO> GetCharacteristicsByName(string Name)
        {
            List<Characteristic> characteristics = context.Characteristics.Where(_ => _.Name.Contains(Name)).ToList();

            List<GetCharacteristicDTO> result = characteristics
                .Select(_ => new GetCharacteristicDTO { Name = _.Name, CharacteristicID = _.ID }).ToList();
            
            return result;

        }
        public void DeleteCharacteristic(int CharacteristicID)
        {
            Characteristic OldCharacteristic = context.Characteristics.FirstOrDefault(c => c.ID == CharacteristicID);

            if (OldCharacteristic != null)
            {
                throw new Exception("Характеристика не найдена");

            }

            context.Characteristics.Remove(OldCharacteristic);
            context.SaveChanges();
        }
    }
}
