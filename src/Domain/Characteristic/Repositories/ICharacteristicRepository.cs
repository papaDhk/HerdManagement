using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HerdManagement.Domain.Characteristic.Entities;

namespace HerdManagement.Domain.Characteristic.Repositories
{
    public interface ICharacteristicRepository
    {
        Task<BreedCharacteristic> AddBreedCharacteristic(BreedCharacteristic breedCharacteristic);
        Task<SpecieCharacteristic> AddSpecieCharacteristic(SpecieCharacteristic specieCharacteristic);
        IEnumerable<BreedCharacteristic> GetBreedCharacteristics();
        IEnumerable<SpecieCharacteristic> GetSpecieCharacteristics();
        IEnumerable<BreedCharacteristic> GetBreedCharacteristicsByBreedId(int Id);
        IEnumerable<SpecieCharacteristic> GetSpecieCharacteristicsBySpecieId(int Id);
    }
}
