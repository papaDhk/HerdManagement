using HerdManagement.Domain.Reproduction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerdManagement.Domain.Reproduction.Repository
{
    public interface IAnimalRepository
    {
        Task<Female> AddNewFemaleAsync(Female female);
        Task<Male> AddNewMaleAsync(Male male);
        Female GetFemaleByNumber(int femaleNumber);
        Female GetFemaleById(int femaleId);
        IEnumerable<Female> GetFemales();
        Male GetMaleByNumber(int maleNumber);
        Male GetMaleById(int maleId);
        IEnumerable<Male> GetMales();
        IEnumerable<Male> GetMalesByHerdId(int herdId);
        IEnumerable<Female> GetFemalesByHerdId(int herdId);
        Task<Female> UpdateFemaleAsync(Female female);
        Task<Male> UpdateMaleAsync(Male male);
        Task<YoungAnimal> AddNewYoungAnimalAsync(YoungAnimal youngAnimal);
        IEnumerable<YoungAnimal> GetYoungAnimals();
        IEnumerable<YoungAnimal> GetYoungAnimalsByHerdId(int herdId);
        YoungAnimal GetYoungAnimalByNumber(int youngAnimalNumber);
        YoungAnimal GetYoungAnimalById(int youngAnimalId);
        Task<YoungAnimal> UpdateYoungAnimalAsync(YoungAnimal youngAnimal);

    }

}
