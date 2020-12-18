using HerdManagement.Domain.Reproduction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerdManagement.Domain.SpecieBreed.Repository
{
    public interface IAnimalRepository
    {
        Task<Female> AddNewFemaleAsync(Female female);
        Task<Male> AddNewMaleAsync(Male male);
        Female GetFemaleByNumber(int femaleNumber);
        IEnumerable<Female> GetFemales();
        Male GetMaleByNumber(int maleNumber);
        IEnumerable<Male> GetMales();
        IEnumerable<Male> GetMalesByHerdId(int herdId);
        Task<Female> UpdateFemaleAsync(Female female);
        Task<Male> UpdateMaleAsync(Male male);
    }
}
