using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HerdManagement.Domain.Characteristic.Entities;
using HerdManagement.Domain.Characteristic.Repositories;
using HerdManagement.Domain.Reproduction.Repository;
using Microsoft.EntityFrameworkCore;

namespace HerdManagement.Infrastructure.Persistence.Repository
{
    public class CharacteristicRepository : ICharacteristicRepository
    {
        private CharacteristicDbContext _characteristicDbContext;

        public CharacteristicRepository(CharacteristicDbContext characteristicDbContext)
        {
            _characteristicDbContext = _characteristicDbContext ?? throw new ArgumentNullException(nameof(characteristicDbContext));
            _characteristicDbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public Task<BreedCharacteristic> AddBreedCharacteristic(BreedCharacteristic breedCharacteristic)
        {
            throw new NotImplementedException();
        }

        public Task<SpecieCharacteristic> AddSpecieCharacteristic(SpecieCharacteristic specieCharacteristic)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BreedCharacteristic> GetBreedCharacteristics()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BreedCharacteristic> GetBreedCharacteristicsByBreedId(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SpecieCharacteristic> GetSpecieCharacteristics()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SpecieCharacteristic> GetSpecieCharacteristicsBySpecieId(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
