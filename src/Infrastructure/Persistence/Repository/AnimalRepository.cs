using HerdManagement.Domain.Reproduction.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HerdManagement.Infrastructure.Persistence.Utils;
using HerdManagement.Domain.Reproduction.Repository;

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

        public Animal GetAnimalById(int animalId)
        {
            return _animalDbContext.Animals
                .Include(animal => animal.Herd)
                .Include(animal => animal.Breed)
                .ThenInclude(breed => breed.Specie)
                .Include(animal => animal.FromCalving)
                .FirstOrDefault(animal => animal.Id == animalId);
        }

        //Females

        public async Task<Female> AddNewFemaleAsync(Female female)
        {
            _animalDbContext.AttachGraphForAdditionWithoutDuplicates(female);

            _ = await _animalDbContext.SaveChangesAsync();

            _animalDbContext.UntrackEntities();

            //_animalDbContext.Entry(female).State = EntityState.Detached;

            //_animalDbContext.Entry(female.Herd).State = EntityState.Detached;

            return GetFemaleByNumber(female.Number);

            //return await Task.FromResult(savedFemale.Entity);
        }

        public async Task<Female> UpdateFemaleAsync(Female female)
        {
            _animalDbContext.Update(female);

            _ = await _animalDbContext.SaveChangesAsync();

            _animalDbContext.UntrackEntities();

            //_animalDbContext.Entry(female).State = EntityState.Detached;

            return GetFemaleByNumber(female.Number);
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
            return _animalDbContext.Females
                .Include(female => female.Herd)
                .Include(female => female.Breed)
                .ThenInclude(breed => breed.Specie)
                .Include(female => female.FromCalving)
                .FirstOrDefault(female => female.Number == femaleNumber);
        }

        public Female GetFemaleById(int femaleId)
        {
            return _animalDbContext.Females
                .Include(female => female.Herd)
                .Include(female => female.Breed)
                .ThenInclude(breed => breed.Specie)
                .Include(female => female.FromCalving)
                .FirstOrDefault(female => female.Id == femaleId);
        }

        public Female GetFemaleWithReproductionsById(int femaleId)
        {
            return _animalDbContext.Females
                .Include(female => female.Herd)
                .Include(female => female.Breed)
                .ThenInclude(breed => breed.Specie)
                .Include(female => female.FromCalving)
                .Include(female => female.Reproductions)
                .FirstOrDefault(female => female.Id == femaleId);
        }

        public Female GetAnimalWithReproductions(Female female)
        {
            _animalDbContext.Entry(female).State = EntityState.Unchanged;
            _animalDbContext.Entry(female).Collection(female => female.Reproductions).Load();

            foreach (var reproduction in female.Reproductions)
            {
                _animalDbContext.Entry(reproduction).Collection(r => r.States).Load();
                _animalDbContext.Entry(reproduction).Collection(r => r.Calvings).Load();

                foreach (var calving in reproduction.Calvings)
                {
                    _animalDbContext.Entry(calving).Reference(r => r.Animal).Load();
                    _animalDbContext.Entry(calving.Animal).Reference(a => a.Breed).Load();
                    _animalDbContext.Entry(calving.Animal).Reference(a => a.Herd).Load();
                    _animalDbContext.Entry(calving.Animal.Breed).Reference(b => b.Specie).Load();
                }
            }

            _animalDbContext.UntrackEntities();
            return female;
        }
        //Males

        public async Task<Male> AddNewMaleAsync(Male male)
        {
             _animalDbContext.AttachGraphForAdditionWithoutDuplicates(male);

            _ = await _animalDbContext.SaveChangesAsync();

            _animalDbContext.UntrackEntities();

            //_animalDbContext.Entry(male).State = EntityState.Detached;

            //_animalDbContext.Entry(male.Herd).State = EntityState.Detached;

            //await _animalDbContext.Entry(male).Reference(male => male.Breed).LoadAsync();

            return GetMaleByNumber(male.Number);
        }


        public async Task<Male> UpdateMaleAsync(Male male)
        {
            _animalDbContext.Update(male);

            _ = await _animalDbContext.SaveChangesAsync();

            _animalDbContext.UntrackEntities();

            //_animalDbContext.Entry(male).State = EntityState.Detached;

            //return await Task.FromResult(male);

            return GetMaleByNumber(male.Number);
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
            return _animalDbContext.Males
                .Include(male => male.Herd)
                .Include(male => male.Breed)
                .ThenInclude(breed => breed.Specie)
                .Include(male => male.FromCalving)
                .FirstOrDefault(male => male.Number == maleNumber);
        }

        public Male GetMaleById(int maleId)
        {
            return _animalDbContext.Males
                .Include(male => male.Herd)
                .Include(male => male.Breed)
                .ThenInclude(breed => breed.Specie)
                .Include(male => male.FromCalving)
                .FirstOrDefault(male => male.Id == maleId);
        }

        public Male GetAnimalWithReproductions(Male male)
        {
            _animalDbContext.Entry(male).State = EntityState.Unchanged;
            _animalDbContext.Entry(male).Collection(male => male.Reproductions).Load();

            foreach (var reproduction in male.Reproductions)
            {
                _animalDbContext.Entry(reproduction).Collection(r => r.States).Load();
            }

            _animalDbContext.UntrackEntities();

            return male;
        }


        //Young animals

        public async Task<YoungAnimal> AddNewYoungAnimalAsync(YoungAnimal youngAnimal)
        {
            _animalDbContext.AttachGraphForAdditionWithoutDuplicates(youngAnimal);

            _ = await _animalDbContext.SaveChangesAsync();

            _animalDbContext.UntrackEntities();

            //_animalDbContext.Entry(youngAnimal).State = EntityState.Detached;

            //_animalDbContext.Entry(youngAnimal.Herd).State = EntityState.Detached;

            return GetYoungAnimalByNumber(youngAnimal.Number);
        }

        public async Task<YoungAnimal> UpdateYoungAnimalAsync(YoungAnimal youngAnimal)
        {
            _animalDbContext.Update(youngAnimal);

            _ = await _animalDbContext.SaveChangesAsync();

            _animalDbContext.UntrackEntities();

            return GetYoungAnimalByNumber(youngAnimal.Number);

            //_animalDbContext.Entry(youngAnimal).State = EntityState.Detached;

            //return await Task.FromResult(youngAnimal);
        }

        public IEnumerable<YoungAnimal> GetYoungAnimals()
        {
            return _animalDbContext.YoungAnimals
                   .Include(youngAnimal => youngAnimal.Breed)
                   .ThenInclude(breed => breed.Specie);
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
            return _animalDbContext.YoungAnimals
                .Include(youngAnimal => youngAnimal.Herd)
                .Include(youngAnimal => youngAnimal.Breed)
                .ThenInclude(youngAnimal => youngAnimal.Specie)
                .Include(youngAnimal => youngAnimal.FromCalving)
                .FirstOrDefault(youngAnimal => youngAnimal.Number == youngAnimalNumber);
        }

        public YoungAnimal GetYoungAnimalById(int youngAnimalId)
        {
            return _animalDbContext.YoungAnimals
                .Include(youngAnimal => youngAnimal.Herd)
                .Include(youngAnimal => youngAnimal.Breed)
                .ThenInclude(youngAnimal => youngAnimal.Specie)
                .Include(youngAnimal => youngAnimal.FromCalving)
                .FirstOrDefault(youngAnimal => youngAnimal.Id == youngAnimalId);
        }


    }
}
