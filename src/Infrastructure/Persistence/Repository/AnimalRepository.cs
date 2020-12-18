using HerdManagement.Domain.Reproduction.Entities;
using HerdManagement.Domain.SpecieBreed.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerdManagement.Infrastructure.Persistence.Repository
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly AnimalDbContext _animalDbContext;

        public AnimalRepository(AnimalDbContext animalDbContext)
        {
            _animalDbContext = animalDbContext ?? throw new ArgumentNullException(nameof(animalDbContext));
        }

        public async Task<Female> AddNewFemaleAsync(Female female)
        {
            var savedFemale = _animalDbContext.Females.Attach(female);

            _ = await _animalDbContext.SaveChangesAsync();

            return await Task.FromResult(savedFemale.Entity);
        }

        public async Task<Male> AddNewMaleAsync(Male male)
        {
            var savedMale = _animalDbContext.Males.Attach(male);

            _ = await _animalDbContext.SaveChangesAsync();

            return await Task.FromResult(savedMale.Entity);
        }

        public IEnumerable<Male> GetMales()
        {
            return _animalDbContext.Males.AsNoTracking();
        }

        public IEnumerable<Female> GetFemales()
        {
            return _animalDbContext.Females.AsNoTracking();
        }

        public IEnumerable<Male> GetMalesByHerdId(int herdId)
        {
            return _animalDbContext.Males.AsNoTracking().Where(male => male.Herd.Id == herdId);
        }

        public Male GetMaleByNumber(int maleNumber)
        {
            return _animalDbContext.Males.AsNoTracking().Include(male => male.Breed).Where(male => male.Number == maleNumber).FirstOrDefault();
        }

        public Female GetFemaleByNumber(int femaleNumber)
        {
            return _animalDbContext.Females.AsNoTracking().Where(female => female.Number == femaleNumber).FirstOrDefault();
        }

        
        public async Task<Male> UpdateMaleAsync(Male male)
        {
            _animalDbContext.Entry<Male>(male).State = EntityState.Modified;

            _ = await _animalDbContext.SaveChangesAsync();

            return await Task.FromResult(male);
        }

        public async Task<Female> UpdateFemaleAsync(Female female)
        {
             _animalDbContext.Females.Update(female);

             _ = await _animalDbContext.SaveChangesAsync();

            return await Task.FromResult(female);
        }
    }
}
