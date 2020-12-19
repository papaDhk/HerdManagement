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
            _animalDbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        //Females

        public async Task<Female> AddNewFemaleAsync(Female female)
        {
            var savedFemale = _animalDbContext.Females.Attach(female);

            _ = await _animalDbContext.SaveChangesAsync();

            _animalDbContext.Entry(female).State = EntityState.Detached;

            return await Task.FromResult(savedFemale.Entity);
        }

        public async Task<Female> UpdateFemaleAsync(Female female)
        {
            _animalDbContext.Entry(female).State = EntityState.Modified;

            _ = await _animalDbContext.SaveChangesAsync();

            _animalDbContext.Entry(female).State = EntityState.Detached;

            return await Task.FromResult(female);
        }

        public IEnumerable<Female> GetFemales()
        {
            return _animalDbContext.Females;
        }

        public IEnumerable<Female> GetFemalesByHerdId(int herdId)
        {
            return _animalDbContext.Females
                   .Include(female => female.Breed)
                   .ThenInclude(breed => breed.Specie)
                   .Where(male => male.Herd.Id == herdId);
        }

        public Female GetFemaleByNumber(int femaleNumber)
        {
            return _animalDbContext.Females.Include(female => female.Breed).Where(female => female.Number == femaleNumber).FirstOrDefault();
        }


        //Males

        public async Task<Male> AddNewMaleAsync(Male male)
        {
            var savedMale = _animalDbContext.Males.Attach(male);

            _ = await _animalDbContext.SaveChangesAsync();

            _animalDbContext.Entry(male).State = EntityState.Detached;

            return await Task.FromResult(savedMale.Entity);
        }


        public async Task<Male> UpdateMaleAsync(Male male)
        {
            _animalDbContext.Entry(male).State = EntityState.Modified;

            _ = await _animalDbContext.SaveChangesAsync();

            _animalDbContext.Entry(male).State = EntityState.Detached;

            return await Task.FromResult(male);
        }

        public IEnumerable<Male> GetMales()
        {
            return _animalDbContext.Males;
        }        

        public IEnumerable<Male> GetMalesByHerdId(int herdId)
        {
            return _animalDbContext.Males
                   .Include(male => male.Breed)
                   .ThenInclude(breed => breed.Specie)
                   .Where(male => male.Herd.Id == herdId);
        }       

        public Male GetMaleByNumber(int maleNumber)
        {
            return _animalDbContext.Males.Include(male => male.Breed).Where(male => male.Number == maleNumber).FirstOrDefault();
        }


        //Young animals

        public async Task<YoungAnimal> AddNewYoungAnimalAsync(YoungAnimal youngAnimal)
        {
            var savedYoungAnimal = _animalDbContext.YoungAnimals.Attach(youngAnimal);

            _ = await _animalDbContext.SaveChangesAsync();

            _animalDbContext.Entry(youngAnimal).State = EntityState.Detached;

            return await Task.FromResult(savedYoungAnimal.Entity);
        }

        public async Task<YoungAnimal> UpdateYoungAnimalAsync(YoungAnimal youngAnimal)
        {
            _animalDbContext.Entry(youngAnimal).State = EntityState.Modified;

            _ = await _animalDbContext.SaveChangesAsync();

            _animalDbContext.Entry(youngAnimal).State = EntityState.Detached;

            return await Task.FromResult(youngAnimal);
        }

        public IEnumerable<YoungAnimal> GetYoungAnimals()
        {
            return _animalDbContext.YoungAnimals;
        }

        public IEnumerable<YoungAnimal> GetYoungAnimalsByHerdId(int herdId)
        {
            return _animalDbContext.YoungAnimals
                   .Include(youngAnimal => youngAnimal.Breed)
                   .ThenInclude(breed => breed.Specie)
                   .Where(youngAnimal => youngAnimal.Herd.Id == herdId);
        }

        public YoungAnimal GetYoungAnimalByNumber(int youngAnimalNumber)
        {
            return _animalDbContext.YoungAnimals.Include(youngAnimal => youngAnimal.Breed).Where(youngAnimal => youngAnimal.Number == youngAnimalNumber).FirstOrDefault();
        }

    }
}
